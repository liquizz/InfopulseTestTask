using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;

namespace WebPortal.Logic.Queries.Interfaces
{
    public interface ICustomersQueries
    {
        public List<CustomerDTO> GetCustomers();
        List<Customers> GetCustomersList();
    }
}