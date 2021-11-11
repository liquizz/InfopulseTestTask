using System;
using System.Threading.Tasks;

namespace ProductsService.Logic.Services.Interfaces
{
    public interface IProductsWriteService
    {
        Task<object> EditProduct(int productId, string productName, int productCategoryId, int quantity, int price,
            DateTime productDate, string productDescription, int productSizeId, int productDescriptionId);
        public Task<bool> DeleteProduct(int productId);

        Task<bool> CreateProduct(string productName, int productCategoryId, int quantity, int price,
            DateTime timeCreated, string productDescription, int productSizeId);
    }
}