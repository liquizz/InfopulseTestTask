using System.Collections.Generic;
using System.Threading.Tasks;
using WebPortal.Database.Models;

namespace WebPortal.Database.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<Customers> GetCustomerByIdAsync(int id);
        public Task<List<Customers>> GetCustomers();
        public Task<Customers> AddCustomer(Customers user);
        public Task<Customers> DeleteCustomerById(int id);
        public Task<bool> SaveChangesAsync();
    }
}