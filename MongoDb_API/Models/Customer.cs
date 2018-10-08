using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_API.Models
{
    public class Customer
    {
        [BsonId]
        public string _Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("contact")]
        public string Contact { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
    }
}
