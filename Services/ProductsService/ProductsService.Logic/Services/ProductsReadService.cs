using System.Collections.Generic;
using ProductsService.Logic.DTOModels;
using ProductsService.Logic.Queries.Interfaces;
using ProductsService.Logic.Services.Interfaces;
using WebPortal.Database.Models;

namespace ProductsService.Logic.Services
{
    public class ProductsReadService : IProductsReadService
    {
        private readonly IProductsQueries _queries;
        
        public ProductsReadService(IProductsQueries queries)
        {
            _queries = queries;
        }
        
        public GetProductDTO GetProduct(int productId)
        {
            return _queries.GetProduct(productId);
        }
        
        public List<GetProductsDTO> GetProducts()
        {
            return _queries.GetProducts();
        }
        
        public List<ProductCategories> GetCategories()
        {
            return _queries.GetCategories();
        }
        
        public List<ProductSizes> GetSizes()
        {
            return _queries.GetSizes();
        }
    }
}