using System;
using System.Threading.Tasks;
using WebPortal.Database.Models;
using WebPortal.Database.Repositories;
using WebPortal.Database.Repositories.Interfaces;
using WebPortal.Logic.WriteServices.Interfaces;

namespace WebPortal.Logic.WriteServices
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
                {Address = address, CreatedDate = createdDate, Name = name});

            return await _repository.SaveChangesAsync();
        }




        //public async void aaa()
        //{
        //    //edit 
        //    var repo = new CustomerRepository();

        //    var customer = await repo.GetCustomerByIdAsync(2);

        //    customer.Name = "Petya 2";

        //    repo.SaveChangesAsync();


        //    //delete



        //}
    }
}