using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPortal.Database.Models;
using WebPortal.Database.Repositories.Interfaces;
using WebPortal.Logic.WriteServices.Interfaces;

namespace WebPortal.Logic.WriteServices
{
    public class ProductsWriteService : IProductsWriteService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsWriteService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<bool> CreateProduct(string productName, int productCategoryId, int quantity, int price, DateTime timeCreated, string productDescription, int productSizeId)
        {
            var category = _productsRepository.GetProductCategoryByIdAsync(productCategoryId).Result;
            var size = _productsRepository.GetProductSizeByIdAsync(productSizeId).Result;

            var product = new Products() { Name = productName, ProductCategories = category, Quantity = quantity, Price = price, ProductDate = timeCreated, ProductSizes = size, ProductDescription = new ProductDescriptions() { Description = productDescription } };
            await _productsRepository.AddProducts(product);
            return await _productsRepository.SaveChangesAsync();
        }

        public object DeleteProduct(int productId)
        {
            return _productsRepository.DeleteProductsById(productId);
        }

        public async Task<object> EditProduct(int productId, string productName, int productCategoryId, int quantity, int price, DateTime productDate, string productDescription, int productSizeId)
        {
            var product = _productsRepository.GetProductsByIdsAsync(new List<int>() {productId}).FirstOrDefault();
            var category = _productsRepository.GetProductCategoryByIdAsync(productCategoryId).Result;
            var size = _productsRepository.GetProductSizeByIdAsync(productSizeId).Result;
            var description = _productsRepository.GetProductDescriptionsByIdAsync(product.ProductDescription.ProductDescriptionId).Result;

            description.Description = productDescription;

            _productsRepository.UpdateDescription(description);

            product.Name = productName;
            product.ProductCategories = category;
            product.Quantity = quantity;
            product.Price = price;
            product.ProductDate = productDate;
            product.ProductDescription = description;
            product.ProductSizes = size;

            _productsRepository.UpdateProduct(product);
            return await _productsRepository.SaveChangesAsync();
        }
    }
}