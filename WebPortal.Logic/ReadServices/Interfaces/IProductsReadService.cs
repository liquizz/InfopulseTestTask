using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;

namespace WebPortal.Logic.ReadServices.Interfaces
{
    public interface IProductsReadService
    {
        public GetProductDTO GetProduct(int productId);
        public List<GetProductsDTO> GetProducts();
        List<ProductCategories> GetCategories();
        List<ProductSizes> GetSizes();
    }
}