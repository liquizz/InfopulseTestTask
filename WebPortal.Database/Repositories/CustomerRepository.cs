using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebPortal.Database.Models;
using WebPortal.Database.Repositories.Interfaces;

namespace WebPortal.Database.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IWebPortalContext _context;

        public CustomerRepository(IWebPortalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customers> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(_ => _.CustomerId == id);
        }

        public async Task<List<Customers>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customers> AddCustomer(Customers user)
        {
            var customer = await _context.Customers.AddAsync(user);
            return customer.Entity;
        }

        public async Task<Customers> DeleteCustomerById(int id)
        {
            var customer = await GetCustomerByIdAsync(id);

            var result = _context.Customers.Remove(customer);

            return result.Entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
