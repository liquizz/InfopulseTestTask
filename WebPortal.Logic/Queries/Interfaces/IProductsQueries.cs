using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;

namespace WebPortal.Logic.Queries.Interfaces
{
    public interface IProductsQueries
    {
        public GetProductsDTO GetProduct(int productId);
        public List<GetProductsDTO> GetProducts();
        List<ProductCategories> GetCategories();
        List<ProductSizes> GetSizes();
    }
}