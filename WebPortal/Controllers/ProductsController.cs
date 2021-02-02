using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPortal.Database.Models;
using WebPortal.Logic.ReadServices.Interfaces;

namespace WebPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsReadService _productsReadService;

        public ProductsController(IProductsReadService service)
        {
            _productsReadService = service;
        }

        [HttpGet]
        public Products GetProduct(int productId)
        {
            return _productsReadService.GetProduct(productId);
        }

        [HttpGet]
        public List<Products> GetProducts()
        {
            return _productsReadService.GetProducts();
        }
    }
}
