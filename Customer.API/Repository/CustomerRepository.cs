using Customer.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.API.Repository
{
    public interface ICustomerRepository
    {
        Task<tbl_Customer> Add(tbl_Customer customer);
        Task<tbl_Customer> GetById(long id);
        Task<List<tbl_Customer>> GetCustomers();
        Task<tbl_Customer> RemoveById(long id);
        Task<tbl_Customer> Update(tbl_Customer customer);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDBContext _db;

        public CustomerRepository(CustomerDBContext db)
        {
            _db = db;
        }
        public async Task<List<tbl_Customer>> GetCustomers()
        {
            return await _db.tbl_Customers.OrderByDescending(e=>e.Id).ToListAsync();
        }
        public async Task<tbl_Customer> Add(tbl_Customer customer)
        {
            var result = await _db.AddAsync(customer);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<tbl_Customer> Update(tbl_Customer customer)
        {
            var result = await _db.tbl_Customers.Where(e => e.Id == customer.Id).FirstOrDefaultAsync();
            result.Name = customer.Name;
            result.DOB = customer.DOB;
            await _db.SaveChangesAsync();
            return result;
        }
        public async Task<tbl_Customer> GetById(long id)
        {
            var result = await _db.tbl_Customers.Where(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task<tbl_Customer> RemoveById(long id)
        {
            var result = await _db.tbl_Customers.Where(e => e.Id == id).FirstOrDefaultAsync();
            _db.Remove(result);
            return result;
        }
    
    }
  

}

