using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;
using WebPortal.Logic.Queries.Interfaces;
using WebPortal.Logic.ReadServices.Interfaces;

namespace WebPortal.Logic.ReadServices
{
    public class CustomerReadService : ICustomersReadService
    {
        private readonly ICustomersQueries _queries;

        public CustomerReadService(ICustomersQueries queries)
        {
            _queries = queries;
        }

        public List<CustomerDTO> GetCustomers()
        {
            return _queries.GetCustomers();
        }
    }
}