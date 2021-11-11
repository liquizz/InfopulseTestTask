using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrdersService.Logic.DTOModels;
using WebPortal.Database.Models;

namespace OrdersService.Logic.Services.Interfaces
{
    public interface IOrdersWriteService
    {
        public Task<Orders> CreateOrder(DateTime orderDate, int customerId, int statusId, int totalCost, 
            List<ProductsListDTO> productsList);

        Task<bool> EditOrder(int orderId, DateTime orderDate, int customerId, int statusId, int totalCost,
            List<ProductsListDTO> productsList);
    }
}