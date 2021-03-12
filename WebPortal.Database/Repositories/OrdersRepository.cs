using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPortal.Database.Models;
using WebPortal.Database.Repositories.Interfaces;

namespace WebPortal.Database.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IWebPortalContext _context;

        public OrdersRepository(IWebPortalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Orders> GetOrdersByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(_ => _.OrderId == id);
        }

        public async Task<OrderStatuses> GetOrderStatusesByIdAsync(int id)
        {
            return await _context.OrdersStatuses.FirstOrDefaultAsync(_ => _.StatusId == id);
        }

        public async Task<List<OrdersProducts>> GetOrdersProductsByOrderIdAsync(int orderId)
        {
            return await _context.OrdersProducts.Where(_ => _.Order.OrderId == orderId).ToListAsync();
        } 

        public async Task<List<Orders>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Orders> AddOrders(Orders orders)
        {
            var order = await _context.Orders.AddAsync(orders);
            return order.Entity;
        }

        public Orders UpdateOrders(Orders orders)
        {
            var order = _context.Orders.Update(orders);
            return order.Entity;
        }

        public async Task<bool> DeleteOrdersProductsByOrderIdAsync(int orderId)
        {
            var ordersProducts = await this.GetOrdersProductsByOrderIdAsync(orderId);

            try
            {
                _context.OrdersProducts.RemoveRange(ordersProducts);
                return _context.SaveChangesAsync().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<Orders> DeleteOrdersById(int id)
        {
            var order = await GetOrdersByIdAsync(id);

            var result = _context.Orders.Remove(order);

            return result.Entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}