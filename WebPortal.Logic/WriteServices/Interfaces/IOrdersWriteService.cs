using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPortal.Database.Models;
using WebPortal.Logic.DTOModels;

namespace WebPortal.Logic.WriteServices.Interfaces
{
    public interface IOrdersWriteService
    {
        public Task<Orders> CreateOrder(DateTime orderDate, int customerId, int statusId, int totalCost, 
            List<ProductsListDTO> productsList);

        Task<bool> EditOrder(int orderId, DateTime orderDate, int customerId, int statusId, int totalCost,
            List<ProductsListDTO> productsList);
    }
}