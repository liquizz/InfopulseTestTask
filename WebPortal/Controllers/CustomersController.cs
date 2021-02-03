﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebPortal.API.Filters;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;
using WebPortal.Logic.ReadServices.Interfaces;
using WebPortal.Logic.WriteServices.Interfaces;

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

        [HttpPost]
        public async Task<bool> CreateCustomer([FromForm] CustomerDTO customerData)
        {
            return await _writeService.CreateCustomer(customerData.Name, customerData.Address,
                    customerData.CreatedDate);
        }

    }
}
