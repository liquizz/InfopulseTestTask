using System.Collections.Generic;
using OrdersService.Logic.DTOModels;
using WebPortal.Database.Models;

namespace OrdersService.Logic.Queries.Interfaces
{
    public interface IOrdersQueries
    {
        GetOrderDTO GetOrder(int orderId);
        List<GetOrderDTO> GetOrders();
        List<OrderStatuses> GetOrderStatuses();
        List<GetOrdersProducts> GetOrdersProducts(int orderId);
    }
}