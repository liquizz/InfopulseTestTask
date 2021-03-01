using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebPortal.Database.Models;
using WebPortal.helpers;
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

        [HttpGet("{productId}")]
        public GetProductsDTO GetProduct(int productId)
        {
            return _productsReadService.GetProduct(productId);
        }

        [HttpGet("sizes")]
        public List<ProductSizes> GetSizes()
        {
            return _productsReadService.GetSizes();
        }

        [HttpGet]
        public List<GetProductsDTO> GetProducts()
        {
            return _productsReadService.GetProducts();
        }
        
        [HttpGet("categories")]
        public List<ProductCategories> GetCategories()
        {
            return _productsReadService.GetCategories();
        }
        
        [HttpPost("create")]
        public async Task<bool> CreateProduct(JsonElement createProductData)
        {
            var deserializedProductData = JsonDeserializeHelper.ToObject<CreateProductDTO>(createProductData);

            return await _productsWriteService.CreateProduct(deserializedProductData.ProductName, deserializedProductData.ProductCategoryId,
                deserializedProductData.Quantity, deserializedProductData.Price, deserializedProductData.ProductDate,
                deserializedProductData.ProductDescription, deserializedProductData.ProductSizeId);
        }

        [HttpDelete("delete/{productId}")]
        public object DeleteProduct(int productId)
        {
            // var deserializedProductData = JsonDeserializeHelper.ToObject<DeleteProductDTO>(deleteProductData);
            
            return _productsWriteService.DeleteProduct(productId);
        }

        [HttpPost("update")]
        public async Task<object> UpdateProduct([FromForm] UpdateProductDTO updateProductData)
        {
            return await _productsWriteService.EditProduct(updateProductData.ProductId, updateProductData.ProductName,
                updateProductData.ProductCategoryId, updateProductData.Quantity, updateProductData.Price,
                updateProductData.ProductDate, updateProductData.ProductDescription, updateProductData.ProductSizeId);
        }

    }
}
