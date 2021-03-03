using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPortal.Database.Models;

namespace WebPortal.Logic.WriteServices.Interfaces
{
    public interface IOrdersWriteService
    {
        public Task<Orders> CreateOrder(DateTime orderDate, int customerId, int statusId, int totalCost, List<int> productsList);

        Task<bool> EditOrder(int orderId, DateTime orderDate, int customerId, int statusId, int totalCost,
            List<int> productsList);
    }
}