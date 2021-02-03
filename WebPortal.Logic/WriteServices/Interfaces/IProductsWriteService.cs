using System;
using System.Threading.Tasks;

namespace WebPortal.Logic.WriteServices.Interfaces
{
    public interface IProductsWriteService
    {
        Task<object> EditProduct(int productId, string productName, int productCategoryId, int quantity, int price,
            DateTime productDate, string productDescription, int productSizeId);
        public object DeleteProduct(int productId);

        Task<bool> CreateProduct(string productName, int productCategoryId, int quantity, int price,
            DateTime timeCreated, string productDescription, int productSizeId);
    }
}