using System.Threading.Tasks;
using WebPortal.Database.Models;

namespace WebPortal.Database.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        Task<Orders> AddOrders(Orders orders);
        Task<bool> SaveChangesAsync();
        Task<Orders> GetOrdersByIdAsync(int id);
        Task<OrderStatuses> GetOrderStatusesByIdAsync(int id);
        Orders UpdateOrders(Orders orders);
    }
}