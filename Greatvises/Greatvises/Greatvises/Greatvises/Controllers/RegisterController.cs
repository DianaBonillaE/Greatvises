using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Http;
using Greatvises.Config;
using Greatvises.Dao;
using Greatvises.Models;

namespace Greatvises.Controllers
{

    [RoutePrefix("api/register")]
    public class RegisterController : ApiController
    {

        RegisterDao registerDao = new RegisterDao();
        ProductDao productDao = new ProductDao();

        public static String[] rndPsw = {"a","b","c","d",  "e","f","g", "h","i","j","k",
                                         "l","m","n","ñ",  "o","p","q", "r","s","t","u",
                                         "v","w","x","y",  "z","#","$", "%","&","?","¡"};
        [Route("code/{name}")]
        public String GetCodeByName(string name)
        {
            Random rnd = new Random();
            String newName = name;
            if (name.Length >= 5)
            {
                newName = name.Substring(0, 5);
                for (int i = 0; i < 5; i++)
                {
                    newName += rndPsw[rnd.Next(0, 32)];
                }
            }
            else
            {
                int size = 10 - name.Length;
                for (int i = 0; i < size; i++)
                {
                    newName += rndPsw[rnd.Next(0, 32)];
                }
            }

            // Save code in the database
            Client client = new Client(name, newName);
            registerDao.RegisterClient(client);
            return newName;
        }


        [Route("request")]
        [HttpPost]
        public String CreateTransactionCode(FormDataCollection formData)
        {
            Random rnd = new Random();
            string[] ip = formData.Get("ip").Split('.');
            string key = formData.Get("key");
            string nameClient = registerDao.searchKey(key);
            if (nameClient.Equals("null"))
            {
                return "No existe el registro de su clave de registro";
            }
            //Si el codigo esta en la base se procede a crear laclave de transaccion
            byte[] ba;
            try
            {
                ba = new byte[] { Byte.Parse(ip[0]), Byte.Parse(ip[1]), Byte.Parse(ip[2]), Byte.Parse(ip[3]) };
            }
            catch (Exception e)
            {
                return "Error";
            }

            string transactionkey = Encoding.ASCII.GetString(ba);
            for (int i = 0; i < 6; i++)
            {
                transactionkey += rndPsw[rnd.Next(0, 32)];
            }
            Client client2 = new Client(nameClient, key, transactionkey);
            registerDao.insertTransactionKey(client2);


            return transactionkey;

        }

    }
}





    

