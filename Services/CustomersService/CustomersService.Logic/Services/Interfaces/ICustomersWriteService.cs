using System;
using System.Threading.Tasks;

namespace CustomersService.Logic.Services.Interfaces
{
    public interface ICustomersWriteService
    {
        public Task<bool> CreateCustomer(string name, string address, DateTime createdDate);
    }
}