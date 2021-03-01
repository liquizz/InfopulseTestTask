using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;

namespace WebPortal.Logic.ReadServices.Interfaces
{
    public interface IOrdersReadService
    {
        List<GetOrderDTO> GetOrders();
        GetOrderDTO GetOrder(int orderId);
        List<OrderStatuses> GetOrderStatuses();
    }
}