using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDb_API.Models
{
    public class CustomerContext:ICustomerContext
    {
        private readonly IMongoDatabase database;
        MongoClient client;

        public CustomerContext(IConfiguration configuration)
        {
            client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
            database = client.GetDatabase(configuration.GetSection("MongoDB:Database").Value);
        }

        public IMongoCollection<Customer> Customers => database.GetCollection<Customer>("Customers");
    }
}
