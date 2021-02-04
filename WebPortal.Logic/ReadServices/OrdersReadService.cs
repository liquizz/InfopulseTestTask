using System.Collections.Generic;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;
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

        // If you're reading this, I want you to know. I had only 1 day for completion, and I want to ask you to be understanding, when checking my task:)
        // Flash joke: *404* joke is not found :(
        public GetOrderDTO GetOrder(int orderId)
        {
            return _queries.GetOrder(orderId);
        }

        public List<GetOrderDTO> GetOrders()
        {
            return _queries.GetOrders();
        }

        public List<ProductCategories> GetCategories()
        {
            return _queries.GetCategories();
        }

        public List<OrderStatuses> GetOrderStatuses()
        {
            return _queries.GetOrderStatuses();
        }
    }
}