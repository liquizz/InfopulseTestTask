using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;
using WebPortal.Logic.ReadServices.Interfaces;
using WebPortal.Logic.WriteServices.Interfaces;

namespace WebPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsReadService _productsReadService;
        private readonly IProductsWriteService _productsWriteService;

        public ProductsController(IProductsReadService productsReadService, IProductsWriteService productsWriteService)
        {
            _productsReadService = productsReadService;
            _productsWriteService = productsWriteService;
        }

        [HttpGet] // Change to DTO
        public Products GetProduct(int productId)
        {
            return _productsReadService.GetProduct(productId);
        }

        [HttpGet] // The same here, too
        public List<Products> GetProducts()
        {
            return _productsReadService.GetProducts();
        }

        [HttpPost]
        public async Task<bool> CreateProduct([FromForm] CreateProductDTO createProductData)
        {
            return await _productsWriteService.CreateProduct(createProductData.ProductName, createProductData.ProductCategoryId,
                createProductData.Quantity, createProductData.Price, createProductData.ProductDate,
                createProductData.ProductDescription, createProductData.ProductSizeId);
        }

        [HttpDelete]
        public object DeleteProduct([FromForm] DeleteProductDTO deleteProductData)
        {
            return _productsWriteService.DeleteProduct(deleteProductData.ProductId);
        }

        [HttpPost]
        public async Task<object> UpdateProduct([FromForm] UpdateProductDTO updateProductData)
        {
            return await _productsWriteService.EditProduct(updateProductData.ProductId, updateProductData.ProductName,
                updateProductData.ProductCategoryId, updateProductData.Quantity, updateProductData.Price,
                updateProductData.ProductDate, updateProductData.ProductDescription, updateProductData.ProductSizeId);
        }

    }
}
