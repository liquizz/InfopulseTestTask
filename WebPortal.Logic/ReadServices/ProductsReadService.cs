using System.Collections.Generic;
using WebPortal.Database.Models;
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

        public Products GetProduct(int productId)
        {
            return _queries.GetProduct(productId);
        }

        public List<Products> GetProducts()
        {
            return _queries.GetProducts();
        }
    }
}