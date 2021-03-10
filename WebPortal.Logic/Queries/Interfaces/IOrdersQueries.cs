using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;

namespace WebPortal.Logic.Queries.Interfaces
{
    public interface IOrdersQueries
    {
        GetOrderDTO GetOrder(int orderId);
        List<GetOrderDTO> GetOrders();
        List<OrderStatuses> GetOrderStatuses();
        List<GetOrdersProducts> GetOrdersProducts(int orderId);
    }
}