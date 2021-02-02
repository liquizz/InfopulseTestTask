using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using WebPortal.Database.Models;
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

        public Orders GetOrder(int orderId)
        {
            var query = $"SELECT * FROM Orders WHERE Orders.OrderId = {orderId};";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Orders>(query).FirstOrDefault();
            }
        }

        public List<Orders> GetOrders()
        {
            var query = $"SELECT * FROM Orders";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Orders>(query).ToList();
            }
        }
    }
}