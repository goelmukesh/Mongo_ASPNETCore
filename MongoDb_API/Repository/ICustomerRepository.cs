using System.Collections.Generic;
using MongoDb_API.Models;

namespace MongoDb_API.Repository
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        Customer GetCustomer(string Id);
        List<Customer> GetCustomers();
        bool DeleteCustomer(string customerId);
        bool UpdateCustomer(string customerId, Customer customer);
    }
}