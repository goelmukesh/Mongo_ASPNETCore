using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDb_API.Models;

namespace MongoDb_API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerContext context;

        public CustomerRepository(ICustomerContext _context)
        {
            this.context = _context;
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.Find(_ => true).ToList();
        }

        public Customer GetCustomer(string Id)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(c => c._Id, Id);
            return context.Customers.Find(filter).FirstOrDefault();
        }

        public void AddCustomer(Customer customer)
        {
            context.Customers.InsertOne(customer);
        }

        public bool DeleteCustomer(string customerId)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(c => c._Id, customerId);
            DeleteResult deleteResult = context.Customers.DeleteOne(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public bool UpdateCustomer(string customerId, Customer customer)
        {
            ReplaceOneResult updateResult = context.Customers.ReplaceOne(filter: c => c._Id == customerId, replacement: customer);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
