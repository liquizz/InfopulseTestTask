using System;
using System.Threading.Tasks;
using CustomersService.Logic.Services.Interfaces;
using WebPortal.Database.Models;
using WebPortal.Database.Repositories.Interfaces;

namespace CustomersService.Logic.Services
{
    public class CustomersWriteService : ICustomersWriteService
    {
        private readonly ICustomerRepository _repository;
        public CustomersWriteService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateCustomer(string name, string address, DateTime createdDate)
        {
            var customer = await _repository.AddCustomer(new Customers()
                { Address = address, CreatedDate = createdDate, Name = name });

            return await _repository.SaveChangesAsync();
        }
    }
}