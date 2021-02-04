using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;

namespace WebPortal.Logic.ReadServices.Interfaces
{
    public interface ICustomersReadService
    {
        public List<CustomerDTO> GetCustomers();
        List<Customers> GetCustomersList();
    }
}