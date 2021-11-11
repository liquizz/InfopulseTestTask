using System.Collections.Generic;
using CustomersService.Logic.DTOModels;
using WebPortal.Database.Models;

namespace CustomersService.Logic.Queries.Interfaces
{
    public interface ICustomersQueries
    {
        public List<CustomerDTO> GetCustomers();
        List<Customers> GetCustomersList();
    }
}