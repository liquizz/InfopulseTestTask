using System.Collections.Generic;
using System.Data;
using System.Linq;
using CustomersService.Logic.DTOModels;
using CustomersService.Logic.Queries.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebPortal.Database.Models;

namespace CustomersService.Logic.Queries
{
    public class CustomersQueries : ICustomersQueries
    {
        private readonly string _connectionString;

        public CustomersQueries(IConfiguration configuration)
        {
            _connectionString = configuration["connectionString"];
        }

        public List<CustomerDTO> GetCustomers()
        {
            var query = $@"select Customers.CustomerId, Customers.Name, Customers.Address, Calculation.TotalUserSum, Calculation.TotalOrders, Customers.CreatedDate
                                from Customers
                                left join (select Customers.CustomerId, SUM(Orders.FinalPrice) as TotalUserSum, COUNT(Orders.OrderId) as TotalOrders 
                                            from Customers
                                            join Orders on Customers.CustomerId = Orders.CustomerId1
                                            group by Customers.CustomerId) as Calculation on Calculation.CustomerId = Customers.CustomerId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<CustomerDTO>(query).ToList();
            }
        }

        public List<Customers> GetCustomersList()
        {
            var query = $@"select * from Customers";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Customers>(query).ToList();
            }
        }
    }
}