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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersReadService _ordersReadService;

        public OrdersController(IOrdersReadService ordersReadService)
        {
            _ordersReadService = ordersReadService;
        }

        [HttpGet]
        public List<Orders> GetOrders()
        {
            return _ordersReadService.GetOrders();
        }

        public Orders GetOrder(int orderId)
        {
            return _ordersReadService.GetOrder(orderId);
        }
    }
}
