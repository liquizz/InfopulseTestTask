using System.Collections.Generic;
using System.Threading.Tasks;
using WebPortal.Database.Models;

namespace WebPortal.Database.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        List<Products> GetProductsByIdsAsync(List<int> ids);
        Task<List<Products>> GetProducts();
        Task<Products> DeleteProductsById(int id);
    }
}