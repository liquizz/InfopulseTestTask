using System.Collections.Generic;
using WebPortal.Database.Models;

namespace WebPortal.Logic.Queries.Interfaces
{
    public interface ICustomersQueries
    {
        public List<Customers> GetCustomers();
    }
}