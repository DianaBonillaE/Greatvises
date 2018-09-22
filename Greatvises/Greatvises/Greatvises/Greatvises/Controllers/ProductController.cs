using Greatvises.Dao;
using Greatvises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;


namespace Greatvises.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        ProductDao productDao = new ProductDao();
        RegisterDao registerDao = new RegisterDao();

        //  http//<Server>/api/product
        [Route("")]
        public List<Product> GetAllProducts()
        {
            return productDao.findAll();
        }

        //  http//<Server>/api/product/{id}
        [Route("{id}")]
        public Product GetProductById(double id)
        {
            return productDao.findById(id+"");
        }

        //  http//<Server>/api/product/find/{name}
        [Route("find/{name}")]
        public Product GetProductByName(string name)
        {
         return productDao.findProductsByName(name)[0];
           
        }


        [Route("buy")]
        [HttpPost]
        public Object BuyProducts(FormDataCollection formData)
        {

            string key = formData.Get("key");
           string productId = formData.Get("id").ToString();
            string quantity = formData.Get("quantity");
            string nameClient = registerDao.searchTransactionKey(key);
            if(nameClient == "null")
            {
                return "Su clave de transaction es incorrecta";
            }
            Object bill = productDao.buy(productId, double.Parse(quantity), nameClient);

            if (bill.Equals("null"))
            {
                return "El producto solicitado no existe en el catálogo";
            }

            return bill;



        }

    }
}
