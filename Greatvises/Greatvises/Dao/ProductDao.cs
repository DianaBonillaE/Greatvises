using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Greatvises.Models;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Greatvises.Dao
{
    public class ProductDao
    {
        private MongoClient mongoClient;
        private IMongoCollection<Product> productCollection;

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
            var productId = new ObjectId(id);
            return productCollection.AsQueryable<Product>().SingleOrDefault(a => a.Id.Equals(productId));
        }


        public List<Product> findProducts(string name)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Name, name);
            return productCollection.Find<Product>(filter).ToList();
        }


        public Boolean buy(string id, string quantity)
        {
            Product product1 = findById(id);
            Double quantity1 = product1.Quantity - Double.Parse(quantity);
            var filter = Builders<Product>.Filter.Eq(product => product.Id, product1.Id);

            productCollection.UpdateOne(filter, Builders<Product>.Update
                 .Set("name", product1.Name)
                     .Set("description", product1.Description)
                     .Set("quantity", quantity1)
                     .Set("price", product1.Price));

            return true;
        }

    }
}
