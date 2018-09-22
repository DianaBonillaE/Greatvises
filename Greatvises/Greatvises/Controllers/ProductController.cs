using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Greatvises.Dao;
using Greatvises.Models;

namespace Greatvises.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
       
        public ProductDao productDao = new ProductDao();
        
        
        [HttpGet]
        public string Index()
        {
           return  productDao.findProducts("Pantalón").ToString();
           
        }
    }
}