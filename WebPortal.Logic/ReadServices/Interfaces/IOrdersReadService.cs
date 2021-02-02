using System.Collections.Generic;
using WebPortal.Database.Models;

namespace WebPortal.Logic.ReadServices.Interfaces
{
    public interface IOrdersReadService
    {
        public List<Orders> GetOrders();
        public Orders GetOrder(int orderId);
    }
}