using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _db;

        public ProductRepository(ProductDBContext db)
        {
            _db = db;
        }
        public async Task<tbl_Product> AddProductAsync(tbl_Product product)
        {
            var result = await _db.AddAsync(product);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<tbl_Product>> GetAllProdcutAsync()
        {
            var result = await _db.tbl_Products.ToListAsync();
            return result;
        }

        public async Task<tbl_Product> GetProductByIdAsync(long id)
        {
            var result = await _db.tbl_Products.Where(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<tbl_Product> RemoveProductByIdAsync(long id)
        {
            var result = await _db.tbl_Products.Where(e => e.Id == id).FirstOrDefaultAsync();
            _db.tbl_Products.Remove(result);
            return result; 
        }

        public async Task<tbl_Product> UpdateProductAsync(tbl_Product product)
        {
            var result = await _db.tbl_Products.Where(e => e.Id == product.Id).FirstOrDefaultAsync();
            result.Name = product.Name;
            result.Quantity = product.Quantity;
            return result;
        }
    }
}
