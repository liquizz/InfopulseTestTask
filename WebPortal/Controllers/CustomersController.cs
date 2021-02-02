using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPortal.Database.Models;
using WebPortal.Logic.ReadServices.Interfaces;

namespace WebPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersReadService _readService;

        public CustomersController(ICustomersReadService service)
        {
            _readService = service;
        }

        [HttpGet]
        public List<Customers> GetCustomers()
        {
            return _readService.GetCustomers();
        }
    }
}
