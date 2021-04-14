using Product.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<tbl_Product>> GetAllProdcutAsync();
        Task<tbl_Product> AddProductAsync(tbl_Product product);
        Task<tbl_Product> UpdateProductAsync(tbl_Product product);
        Task<tbl_Product> RemoveProductByIdAsync(long id);
        Task<tbl_Product> GetProductByIdAsync(long id);
    }
}
