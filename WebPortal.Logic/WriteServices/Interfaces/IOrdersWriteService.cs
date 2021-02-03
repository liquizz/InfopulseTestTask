using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPortal.Logic.WriteServices.Interfaces
{
    public interface IOrdersWriteService
    {
        public Task<bool> CreateOrder(DateTime orderDate, int customerId, int statusId, int totalCost, List<int> productsList);
        public object EditOrder();

        Task<bool> EditOrder(int orderId, DateTime orderDate, int customerId, int statusId, int totalCost,
            List<int> productsList);
    }
}