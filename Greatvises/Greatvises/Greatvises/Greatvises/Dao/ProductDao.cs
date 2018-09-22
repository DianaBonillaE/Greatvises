using Greatvises.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Greatvises.Dao
{
    public class ProductDao
    {
        private MongoClient mongoClient;
        private IMongoCollection<Product> productCollection;
        private IMongoCollection<Bill> billCollection;

        public ProductDao()
        {
             mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            productCollection = db.GetCollection<Product>("product");

        }
        public List<Product> findAll()
        {
            return productCollection.AsQueryable<Product>().ToList();
        }


        public Product findById(string id)
        {
            double productID = Double.Parse(id);
               return productCollection.AsQueryable<Product>().SingleOrDefault(a => a.Id == productID);
        }

        private double CDbl(object text)
        {
            throw new NotImplementedException();
        }

        public List<Product> findProductsByName(string name)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Name, name);
            return productCollection.Find<Product>(filter).ToList();
        }


        public Object buy(string id, double quantity, string nameClient)
        {
            Product product1 = findById(id);
            if(product1 == null)
            {
                return "null";
            }
            if (product1.Quantity == 0)
            {
                return "No hay unidades disponibles del producto solicitado";
            }

            double quantity1 = product1.Quantity -quantity;
            var filter = Builders<Product>.Filter.Eq(product => product.Id, product1.Id);

            productCollection.UpdateOne(filter, Builders<Product>.Update
                 .Set("name", product1.Name)
                     .Set("description", product1.Description)
                     .Set("quantity", quantity1)
                     .Set("price", product1.Price));

         List<Product> products=   productCollection.Find<Product>(filter).ToList();
            Console.WriteLine(nameClient);
            Console.WriteLine(products[0]);
          return  new Bill(nameClient, products[0]);
            
        }

    }
}