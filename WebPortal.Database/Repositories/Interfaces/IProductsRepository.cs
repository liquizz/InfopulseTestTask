using System.Collections.Generic;
using System.Threading.Tasks;
using WebPortal.Database.Models;

namespace WebPortal.Database.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        List<Products> GetProductsByIdsAsync(List<int> ids);
        Task<List<Products>> GetProducts();
        public Products DeleteProductsById(int id);
        Task<Products> AddProducts(Products products);
        Task<ProductCategories> GetProductCategoryByIdAsync(int id);
        Task<ProductSizes> GetProductSizeByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        Task<ProductDescriptions> GetProductDescriptionsByIdAsync(int id);
        ProductDescriptions UpdateDescription(ProductDescriptions descriptions);
        Products UpdateProduct(Products products);
    }
}