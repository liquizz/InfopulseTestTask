using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;
using WebPortal.Logic.Helpers.Sql;
using WebPortal.Logic.Queries.Interfaces;

namespace WebPortal.Logic.Queries
{
    public class ProductsQueries : IProductsQueries
    {
        private readonly string _connectionString;

        public ProductsQueries(IConnectionStringHelper helper)
        {
            _connectionString = helper.ConnectionString;
        }

        public GetProductsDTO GetProduct(int productId)
        {
            var query = $@"select Products.ProductId, Products.Name, ProductCategories.CategoryName, ProductSizes.SizeName, Products.Quantity, Products.Price from Products
                                join ProductCategories on Products.ProductCategoriesCategoryId = ProductCategories.CategoryId
                                join ProductSizes on Products.ProductSizesSizeId = ProductSizes.SizeId
                                where Products.ProductId = {productId}";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<GetProductsDTO>(query).FirstOrDefault();
            }
        }
        
        public List<ProductCategories> GetCategories()
        {
            var query = $@"select * from ProductCategories";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<ProductCategories>(query).ToList();
            }
        }
        
        public List<GetProductsDTO> GetProducts()
        {
            var query = $@"select Products.ProductId, Products.Name, ProductCategories.CategoryName, ProductSizes.SizeName, Products.Quantity, Products.Price from Products
                                join ProductCategories on Products.ProductCategoriesCategoryId = ProductCategories.CategoryId
                                join ProductSizes on Products.ProductSizesSizeId = ProductSizes.SizeId;";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<GetProductsDTO>(query).ToList();
            }
        }
    }
}