using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;
using WebPortal.Logic.Queries.Interfaces;
using WebPortal.Logic.ReadServices.Interfaces;

namespace WebPortal.Logic.ReadServices
{
    public class ProductsReadService : IProductsReadService
    {
        private readonly IProductsQueries _queries;

        public ProductsReadService(IProductsQueries queries)
        {
            _queries = queries;
        }

        public GetProductsDTO GetProduct(int productId)
        {
            return _queries.GetProduct(productId);
        }

        public List<GetProductsDTO> GetProducts()
        {
            return _queries.GetProducts();
        }
    }
}