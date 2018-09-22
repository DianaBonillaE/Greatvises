using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Greatvises.Models
{
    public class Bill
    {

        string nameClient;
        Product product;

        public Bill(string nameClient, Product product)
        {
            this.NameClient = nameClient;
            this.Product = product;
        }

        public string NameClient { get => nameClient; set => nameClient = value; }
        public Product Product { get => product; set => product = value; }
    }
}