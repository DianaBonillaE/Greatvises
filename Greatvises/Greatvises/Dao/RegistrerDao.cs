using Greatvises.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.Configuration;

namespace Greatvises.Dao
{
    public class RegistrerDao
    {
        private MongoClient mongoClient;
        private IMongoCollection<Client> clientCollection;


        public RegistrerDao()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            clientCollection = db.GetCollection<Client>("client");
        }


        public void registerClient(Client client)
        {
            clientCollection.InsertOne(client);

        }


    }
}