using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrdersService.Logic.DTOModels;
using OrdersService.Logic.Services.Interfaces;
using WebPortal.Database.Models;
using WebPortal.Database.Repositories.Interfaces;

namespace OrdersService.Logic.Services
{
    public class OrdersWriteService: IOrdersWriteService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICustomerRepository _customerRepository;
    
        public OrdersWriteService(
            IProductsRepository productsRepository, IOrdersRepository ordersRepository, 
            ICustomerRepository customerRepository)
        {
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
            _customerRepository = customerRepository;
        }
    
        public async Task<Orders> CreateOrder(
            DateTime orderDate, int customerId, int statusId, int totalCost, List<ProductsListDTO> productsList)
        {
            Orders newOrder;
            List<OrdersProducts> newOrdersProducts = new List<OrdersProducts>();
            List<int> productIds = new List<int>();
            
            if (orderDate != null && productsList != null) // This part is redundant.
            {
                foreach (var product in productsList)
                {
                    productIds.Add(product.ProductId);
                }
                
                var products = _productsRepository.GetProductsByIdsAsync(productIds);
    
                newOrder = new Orders()
                {
                    CustomerId = await _customerRepository.GetCustomerByIdAsync(customerId),
                    OrderStatuses = await _ordersRepository.GetOrderStatusesByIdAsync(statusId),
                    FinalPrice = totalCost,
                    OrderDateCreated = orderDate
                };
    
                foreach (var product in products)
                {
                    var newOrderProduct = new OrdersProducts()
                    {
                        Order = newOrder,
                        Product = product,
                        ProductQuantity = productsList.Find(e => 
                            e.ProductId == product.ProductId).ProductId
                    };
                }
            }
            else
            {
                newOrder = new Orders() {OrderDateCreated = orderDate};
            }
            
            var result = await _ordersRepository.AddOrders(newOrder);
    
            await _ordersRepository.SaveChangesAsync();
            
            return result;
        }
    
        public async Task<bool> EditOrder(
            int orderId, DateTime orderDate, int customerId, 
            int statusId, int totalCost, List<ProductsListDTO> productsList)
        {
            List<int> productsIds = new List<int>();
            foreach (var product in productsList)
            {
                productsIds.Add(product.ProductId);
            }
            
            var oldOrder = _ordersRepository.GetOrdersByIdAsync(orderId).Result;
            var customer = _customerRepository.GetCustomerByIdAsync(customerId).Result;
            var status = _ordersRepository.GetOrderStatusesByIdAsync(statusId).Result;
            var products = _productsRepository.GetProductsByIdsAsync(productsIds);
    
            await _ordersRepository.DeleteOrdersProductsByOrderIdAsync(orderId); // May cause problems later...
            
            oldOrder.CustomerId = customer;
            oldOrder.OrderStatuses = status;
            oldOrder.FinalPrice = totalCost;
            
            foreach (var product in products)
            {
                var newOrderProduct = new OrdersProducts()
                {
                    Order = oldOrder,
                    Product = product,
                    ProductQuantity = productsList.Find(e => 
                        e.ProductId == product.ProductId).Quantity
                };
                _productsRepository.AddOrderProduct(newOrderProduct);
            }
            
            _ordersRepository.UpdateOrders(oldOrder);
            return await _ordersRepository.SaveChangesAsync();
        }
    }
    
    }