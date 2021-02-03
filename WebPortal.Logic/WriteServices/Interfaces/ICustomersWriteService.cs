using System;

namespace WebPortal.Logic.WriteServices.Interfaces
{
    public interface ICustomersWriteService
    {
        public bool CreateCustomer(string name, string address, DateTime createdDate);
    }
}