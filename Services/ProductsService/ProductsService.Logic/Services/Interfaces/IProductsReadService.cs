using System.Collections.Generic;
using ProductsService.Logic.DTOModels;
using WebPortal.Database.Models;

namespace ProductsService.Logic.Services.Interfaces
{
    public interface IProductsReadService
    {
        public GetProductDTO GetProduct(int productId);
        public List<GetProductsDTO> GetProducts();
        List<ProductCategories> GetCategories();
        List<ProductSizes> GetSizes();
    }
}