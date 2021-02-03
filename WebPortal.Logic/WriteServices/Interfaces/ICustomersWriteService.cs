using System;
using System.Threading.Tasks;

namespace WebPortal.Logic.WriteServices.Interfaces
{
    public interface ICustomersWriteService
    {
        public Task<bool> CreateCustomer(string name, string address, DateTime createdDate);
    }
}