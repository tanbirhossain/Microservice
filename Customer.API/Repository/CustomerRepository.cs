using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.API.Repository
{
    public interface ICustomerRepository
    {
        Task<string> GetCustomers();
    }
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository()
        {

        }

        public async Task<string> GetCustomers()
        {
            return "All Customers List";
        }
    }

}
