using Greatvises.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Greatvises.Dao
{
    public class RegisterDao
    {
        private MongoClient mongoClient;
        private IMongoCollection<Client> clientCollection;


        public RegisterDao()
        {
             mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            clientCollection = db.GetCollection<Client>("client");
        }


        public void RegisterClient(Client client)
        {
            clientCollection.InsertOne(client);

        }

        public void insertTransactionKey(Client client)
        {
            var filter = Builders<Client>.Filter.Eq(clientTemp => clientTemp.Password, client.Password);

            clientCollection.UpdateOne(filter, Builders<Client>.Update
                .Set("name", client.Name)
                .Set("Password", client.Password)
                .Set("transaction", client.TransactionPassword));
        }

        public string searchKey(string password)
        {

           List<Client> lista= clientCollection.AsQueryable<Client>().ToList();
            foreach (Client client in lista ){
                if (client.Password.Equals(password))
                {
                    return client.Name;
                }
            }
            return "null";
        }

        public string searchTransactionKey(string transactionPassword)
        {

            List<Client> lista = clientCollection.AsQueryable<Client>().ToList();
            foreach (Client client in lista)
            {
                if (client.TransactionPassword.Equals(transactionPassword))
                {
                    return client.Name;
                }
            }
            return "null";

        }
    }
}