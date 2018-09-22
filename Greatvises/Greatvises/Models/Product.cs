using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Greatvises.Models
{
    public class Product
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

        [BsonElement("description")]
        public string Description
        {
            get;
            set;

        }

        [BsonElement("quantity")]
        public double Quantity
        {
            get;
            set;

        }

        [BsonElement("price")]
        public double Price
        {
            get;
            set;

        }

        // [BsonElement("category")]
        //  public array Category
        // {
        //      get;
        //      set;

        //   }
    }
}