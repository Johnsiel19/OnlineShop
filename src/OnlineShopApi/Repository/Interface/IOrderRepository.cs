using OnlineShopApi.Models;

namespace OnlineShopApi.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrders();
        Task<Orders> FindOrder(int orderId);
        Task EditOrder(Orders order);
        Task DeleteOrder(int id);
        Task CreateOrder(Orders order);
    }
}
