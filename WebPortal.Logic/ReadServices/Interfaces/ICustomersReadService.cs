using System.Collections.Generic;
using WebPortal.Database.Models;

namespace WebPortal.Logic.ReadServices.Interfaces
{
    public interface ICustomersReadService
    {
        public List<Customers> GetCustomers();
    }
}