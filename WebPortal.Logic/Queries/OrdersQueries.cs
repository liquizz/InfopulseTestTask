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

        public GetOrderDTO GetOrder(int orderId)
        {
            var query = $@"select Orders.OrderId, Customers.Name, Customers.Address, Orders.FinalPrice, OrdersStatuses.StatusName
                                from Orders
                                join Customers on Customers.CustomerId = Orders.CustomerId1
                                join OrdersStatuses on OrdersStatuses.StatusId = Orders.OrderStatusesStatusId
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
                                join Customers on Customers.CustomerId = Orders.CustomerId1
                                join OrdersStatuses on OrdersStatuses.StatusId = Orders.OrderStatusesStatusId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<GetOrderDTO>(query).ToList();
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