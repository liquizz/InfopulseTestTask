using System.Collections.Generic;
using WebPortal.Logic.DTOModels;

namespace WebPortal.Logic.Queries.Interfaces
{
    public interface ICustomersQueries
    {
        public List<CustomerDTO> GetCustomers();
    }
}