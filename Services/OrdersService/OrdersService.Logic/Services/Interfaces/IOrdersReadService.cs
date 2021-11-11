using System.Collections.Generic;
using OrdersService.Logic.DTOModels;
using WebPortal.Database.Models;

namespace OrdersService.Logic.Services.Interfaces
{
    public interface IOrdersReadService
    {
        List<GetOrderDTO> GetOrders();
        GetOrderDTO GetOrder(int orderId);
        List<OrderStatuses> GetOrderStatuses();
        List<GetOrdersProducts> GetOrdersProducts(int orderId);
    }
}