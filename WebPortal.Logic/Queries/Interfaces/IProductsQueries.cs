using System.Collections.Generic;
using WebPortal.Database.Models;

namespace WebPortal.Logic.Queries.Interfaces
{
    public interface IProductsQueries
    {
        public Products GetProduct(int productId);
        public List<Products> GetProducts();

    }
}