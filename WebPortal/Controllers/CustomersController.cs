using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        //[HttpPost]
        //public async Task<string> PostText()
        //{
        //    using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
        //    {
        //        return await reader.ReadToEndAsync();
        //    }
        //}

        [HttpPost]
        public async Task<byte[]> PostBinary()
        {
            using (var ms = new MemoryStream(2048))
            {
                await Request.Body.CopyToAsync(ms);
                return ms.ToArray(); // returns base64 encoded string JSON result
            }
        }
    }
}
