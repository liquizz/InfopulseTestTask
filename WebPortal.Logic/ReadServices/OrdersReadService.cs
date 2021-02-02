using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.Queries.Interfaces;
using WebPortal.Logic.ReadServices.Interfaces;

namespace WebPortal.Logic.ReadServices
{
    public class OrdersReadService : IOrdersReadService
    {
        readonly IOrdersQueries _queries;
        public OrdersReadService(IOrdersQueries queries)
        {
            _queries = queries;
        }

        public Orders GetOrder(int orderId)
        {
            return _queries.GetOrder(orderId);
        }

        public List<Orders> GetOrders()
        {
            throw new System.NotImplementedException();
        }
    }
}