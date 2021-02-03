using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPortal.Database.Models;
using WebPortal.Database.Repositories.Interfaces;
using WebPortal.Logic.WriteServices.Interfaces;

namespace WebPortal.Logic.WriteServices
{
    public class OrdersWriteService : IOrdersWriteService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrdersWriteService(IProductsRepository productsRepository, IOrdersRepository ordersRepository, ICustomerRepository customerRepository)
        {
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
            _customerRepository = customerRepository;
        }

        public async Task<bool> CreateOrder(DateTime orderDate, int customerId, int statusId, int totalCost, List<int> productsList)
        {
            // GET Products by ids
            // Create order && add products
            // Savechanges

            var products = _productsRepository.GetProductsByIdsAsync(productsList);

            var newOrder = new Orders() {};

            newOrder.Products.AddRange(products);

            await _ordersRepository.AddOrders(newOrder);

            return await _ordersRepository.SaveChangesAsync();
        }

        public async Task<bool> EditOrder(int orderId, DateTime orderDate, int customerId, int statusId, int totalCost, List<int> productsList)
        {
            var oldOrder = _ordersRepository.GetOrdersByIdAsync(orderId).Result;
            var customer = _customerRepository.GetCustomerByIdAsync(customerId).Result;
            var status = _ordersRepository.GetOrderStatusesByIdAsync(statusId).Result;
            var products = _productsRepository.GetProductsByIdsAsync(productsList);

            oldOrder.CustomerId = customer;
            oldOrder.OrderStatuses = status;
            oldOrder.Products = products;
            oldOrder.FinalPrice = totalCost;

            _ordersRepository.UpdateOrders(oldOrder);
            return await _ordersRepository.SaveChangesAsync();
        }
    }
}