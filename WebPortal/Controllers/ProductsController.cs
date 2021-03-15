using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        public GetProductDTO GetProduct(int productId)
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
            var json = createProductData.ToString();
            var deserializedProductData = JsonConvert.DeserializeObject<CreateProductDTO>(json); 
            
            //var deserializedProductData = JsonDeserializeHelper.ToObject<CreateProductDTO>(createProductData);

            return await _productsWriteService.CreateProduct(deserializedProductData.ProductName, deserializedProductData.ProductCategoryId,
                deserializedProductData.Quantity, deserializedProductData.Price, deserializedProductData.ProductDate,
                deserializedProductData.ProductDescription, deserializedProductData.ProductSizeId);
        }

        [HttpDelete("delete/{productId}")]
        public async Task<bool> DeleteProduct(int productId)
        {
            return await _productsWriteService.DeleteProduct(productId);
        }

        [HttpPost("update")]
        public async Task<object> UpdateProduct(JsonElement updateProductData)
        {
            var json = updateProductData.ToString();
            var deserializedProductData = JsonConvert.DeserializeObject<UpdateProductDTO>(json); 
            //JsonDeserializeHelper.ToObject<UpdateProductDTO>(updateProductData);
            

            return await _productsWriteService.EditProduct(deserializedProductData.ProductId, deserializedProductData.ProductName,
                deserializedProductData.ProductCategoryId, deserializedProductData.Quantity, deserializedProductData.Price,
                deserializedProductData.ProductDate, deserializedProductData.ProductDescription, deserializedProductData.ProductSizeId, 
                deserializedProductData.ProductDescriptionId);
        }

    }
}
