using System.Collections.Generic;
using WebPortal.Database.Models;

namespace WebPortal.Logic.Queries.Interfaces
{
    public interface IOrdersQueries
    {
        public List<Orders> GetOrders();
        public Orders GetOrder(int orderId);

    }
}