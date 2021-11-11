using System.Collections.Generic;
using OrdersService.Logic.DTOModels;
using OrdersService.Logic.Queries.Interfaces;
using OrdersService.Logic.Services.Interfaces;
using WebPortal.Database.Models;

namespace OrdersService.Logic.Services
{
    public class OrdersReadService : IOrdersReadService
    {
        readonly IOrdersQueries _queries;
        public OrdersReadService(IOrdersQueries queries)
        {
            _queries = queries;
        }

        public List<GetOrdersProducts> GetOrdersProducts(int orderId)
        {
            return _queries.GetOrdersProducts(orderId);
        }
        
        public GetOrderDTO GetOrder(int orderId)
        {
            return _queries.GetOrder(orderId);
        }

        public List<GetOrderDTO> GetOrders()
        {
            return _queries.GetOrders();
        }

        public List<OrderStatuses> GetOrderStatuses()
        {
            return _queries.GetOrderStatuses();
        }
    }
}