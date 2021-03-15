using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebPortal.API.Filters;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;
using WebPortal.Logic.ReadServices.Interfaces;
using WebPortal.Logic.WriteServices.Interfaces;
using WebPortal.helpers;

namespace WebPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomFilter]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersReadService _readService;
        private readonly ICustomersWriteService _writeService;

        public CustomersController(ICustomersReadService readService, ICustomersWriteService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }

        [HttpGet]
        public List<CustomerDTO> GetCustomers()
        {
            return _readService.GetCustomers();
        }

        [HttpGet("CustomersShort")]
        public List<Customers> GetCustomersList()
        {
            return _readService.GetCustomersList();
        }

        [HttpPost]
        public async Task<bool> CreateCustomer(JsonElement customerData)
        {
            var json = customerData.ToString();
            var deserializedCustomerData = JsonConvert.DeserializeObject<CustomerDTO>(json); 
            
            //var deserializedCustomerData = JsonDeserializeHelper.ToObject<CustomerDTO>(customerData);

            return await _writeService.CreateCustomer(deserializedCustomerData.Name, deserializedCustomerData.Address,
                    deserializedCustomerData.CreatedDate);
        }

    }
}
