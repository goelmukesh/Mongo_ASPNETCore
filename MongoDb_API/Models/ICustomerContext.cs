using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDb_API.Models
{
    public interface ICustomerContext
    {
        IMongoCollection<Customer> Customers { get; }
    }
}
