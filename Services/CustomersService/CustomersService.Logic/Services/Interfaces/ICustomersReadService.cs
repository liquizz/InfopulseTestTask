using System.Collections.Generic;
using CustomersService.Logic.DTOModels;
using WebPortal.Database.Models;

namespace CustomersService.Logic.Services.Interfaces
{
    public interface ICustomersReadService
    {
        public List<CustomerDTO> GetCustomers();
        List<Customers> GetCustomersList();
    }
}