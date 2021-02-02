using System.Collections.Generic;
using WebPortal.Database.Models;

namespace WebPortal.Logic.ReadServices.Interfaces
{
    public interface IProductsReadService
    {
        public Products GetProduct(int productId);
        public List<Products> GetProducts();
    }
}