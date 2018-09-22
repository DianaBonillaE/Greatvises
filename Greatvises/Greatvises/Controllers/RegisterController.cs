using Greatvises.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Greatvises.Controllers
{
    
    [Route("api/register")]
    public class RegisterController : ApiController
    {

        public static String[] rndPsw = {"a","b","c","d",  "e","f","g", "h","i","j","k",
                                         "l","m","n","ñ",  "o","p","q", "r","s","t","u",
                                         "v","w","x","y",  "z","#","$", "%","&","?","¡"};
        [HttpGet]
        public String GetCodeByName(string name)
        {
            Random rnd = new Random();
            String newName = name;
            if (name.Length >= 5 )
            {
                newName = name.Substring(0, 5);
                for(int i = 0; i< 5; i++)
                {
                    newName += rndPsw[rnd.Next(0, 32)];
                }
            }else
            {
                int size = 10 - name.Length;
                for (int i = 0; i < size; i++)
                {
                    newName += rndPsw[rnd.Next(0, 32)];
                }
            }
            return newName;
        }
    }
}
