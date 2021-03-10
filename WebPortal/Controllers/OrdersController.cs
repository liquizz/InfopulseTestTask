using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebPortal.Database.Models;
using WebPortal.helpers;
using WebPortal.Logic.DTOModels;
using WebPortal.Logic.ReadServices.Interfaces;
using WebPortal.Logic.WriteServices.Interfaces;

namespace WebPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersReadService _ordersReadService;
        private readonly IOrdersWriteService _ordersWriteService;

        public OrdersController(IOrdersReadService ordersReadService, IOrdersWriteService ordersWriteService)
        {
            _ordersReadService = ordersReadService;
            _ordersWriteService = ordersWriteService;
        }

        [HttpGet]
        public List<GetOrderDTO> GetOrders()
        {
            return _ordersReadService.GetOrders();
        }

        [HttpGet("{orderId}/products")]
        public List<GetOrdersProducts> GetOrdersProducts(int orderId)
        {
            return _ordersReadService.GetOrdersProducts(orderId);
        }
        
        [HttpGet("{orderId}")]
        public GetOrderDTO GetOrder(int orderId)
        {
            return _ordersReadService.GetOrder(orderId);
        }

        [HttpGet("Statuses")]
        public List<OrderStatuses> GetOrderStatuses()
        {
            return _ordersReadService.GetOrderStatuses();
        }

        [HttpPost]
        public async Task<Orders> CreateOrder(JsonElement createOrderData)
        {
            var deserializedProductData = JsonDeserializeHelper.ToObject<CreateOrderDTO>(createOrderData);

            return await _ordersWriteService.CreateOrder(deserializedProductData.orderDate, deserializedProductData.customerId,
                deserializedProductData.statusId, deserializedProductData.totalCost, 
                deserializedProductData.productsList);
        }
        
        [HttpPost("{orderId}")]
        public async Task<bool> UpdateOrder(JsonElement updateOrderData, int orderId)
        {
            var deserializedProductData = JsonDeserializeHelper.ToObject<UpdateOrderDTO>(updateOrderData);
            
            return await _ordersWriteService.EditOrder(orderId, deserializedProductData.orderDate, 
                deserializedProductData.customerId, deserializedProductData.statusId, 
                deserializedProductData.totalCost, deserializedProductData.productsList);
        }
    }
}
