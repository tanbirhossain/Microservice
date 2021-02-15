using CustomerService.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.API.Service
{
    public interface ICustomerService
    {
        Task<string> GetCustomers();
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> GetCustomers()
        {
            var result = await _customerRepository.GetCustomers();
            return result;
        }
    }
}
