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
    public class OrdersQueries : IOrdersQueries
    {
        private readonly string _connectionString;
        
        public OrdersQueries(IConnectionStringHelper helper)
        {
            _connectionString = helper.ConnectionString;
        }

        public List<GetOrdersProducts> GetOrdersProducts(int orderId)
        {
            var query = $@"select Products.ProductId, Products.Name, ProductSizes.SizeId, ProductSizes.SizeName, OrdersProducts.ProductQuantity, Products.Price from OrdersProducts
                                join Products on Products.ProductId = OrdersProducts.ProductId
                                join ProductSizes on ProductSizes.SizeId = Products.ProductSizesSizeId
                                where OrderId = {orderId};";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<GetOrdersProducts>(query).ToList();
            }
        }
        
        public GetOrderDTO GetOrder(int orderId) // Change query and DTO
        {
            var query = $@"select Orders.OrderId, Customers.CustomerId, Customers.Name, Customers.Address, Orders.FinalPrice, OrdersStatuses.StatusId, OrdersStatuses.StatusName, Orders.OrderDateCreated
                                from Orders
                                join Customers on Customers.customerId = Orders.CustomerId1
                                join OrdersStatuses on OrdersStatuses.statusId = Orders.OrderStatusesStatusId
                                WHERE Orders.OrderId = {orderId};";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<GetOrderDTO>(query).FirstOrDefault();
            }
        }

        public List<GetOrderDTO> GetOrders()
        {
            var query = $@"select Orders.OrderId, Customers.Name, Customers.Address, Orders.FinalPrice, OrdersStatuses.StatusName
                                from Orders
                                join Customers on Customers.customerId = Orders.CustomerId1
                                join OrdersStatuses on OrdersStatuses.statusId = Orders.OrderStatusesStatusId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<GetOrderDTO>(query).ToList();
            }
        }

        public List<OrderStatuses> GetOrderStatuses()
        {
            var query = $@"select * from OrdersStatuses";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<OrderStatuses>(query).ToList();
            }
        }
    }
}