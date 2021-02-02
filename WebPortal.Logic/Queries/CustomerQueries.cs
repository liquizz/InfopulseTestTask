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
            var query = $"SELECT * FROM Customers";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Customers>(query).ToList();
            }
        }
    }
}