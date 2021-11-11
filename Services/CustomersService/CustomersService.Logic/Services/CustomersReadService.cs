using System.Collections.Generic;
using CustomersService.Logic.DTOModels;
using CustomersService.Logic.Queries.Interfaces;
using CustomersService.Logic.Services.Interfaces;
using WebPortal.Database.Models;

namespace CustomersService.Logic.Services
{
    public class CustomersReadService : ICustomersReadService
    {
        private readonly ICustomersQueries _queries;

        public CustomersReadService(ICustomersQueries queries)
        {
            _queries = queries;
        }

        public List<CustomerDTO> GetCustomers()
        {
            return _queries.GetCustomers();
        }

        public List<Customers> GetCustomersList()
        {
            return _queries.GetCustomersList();
        }
    }
}