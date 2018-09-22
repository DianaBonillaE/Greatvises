using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Greatvises.Models
{
    public class Client
    {
        [BsonElement("_id")]
        public double Id
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

    }
}