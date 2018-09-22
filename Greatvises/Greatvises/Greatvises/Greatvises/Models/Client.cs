using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Greatvises.Models
{
    public class Client {
        public Client(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public Client(string name, string password, string transactionPassword) : this(name, password)
        {
            TransactionPassword = transactionPassword;
        }

        [BsonElement("_id")]
        public ObjectId Id
        {
            get;
            set;

        }

        [BsonElement("name")]
    public string Name
    {
        get;
        set;

    }

    [BsonElement("password")]
    public string Password
    {
        get;
        set;

    }

        [BsonElement("transaction")]
        public string TransactionPassword
        {
            get;
            set;

        }

    }
}