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
    public class CustomerQueries : ICustomersQueries
    {
        private readonly string _connectionString;

        public CustomerQueries(IConnectionStringHelper helper)
        {
            _connectionString = helper.ConnectionString;
        }

        public List<Customers> GetCustomers()
        {
            var query = $@"select Customers.Name, Customers.Address, Calculation.TotalUserSum, Calculation.TotalOrders
                                from Customers
                                join (select Customers.CustomerId, SUM(Orders.FinalPrice) as TotalUserSum, COUNT(Orders.OrderId) as TotalOrders 
                                            from Customers
                                            join Orders on Customers.CustomerId = Orders.CustomerId1
                                            group by Customers.CustomerId) as Calculation on Calculation.CustomerId = Customers.CustomerId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Customers>(query).ToList();
            }
        }
    }
}