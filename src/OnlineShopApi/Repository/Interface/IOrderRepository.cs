using OnlineShopApi.Models;

namespace OnlineShopApi.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrders();
        Task<Orders> FindOrder(int orderId);
        Task<bool> EditOrder(Orders order);
        Task<bool> DeleteOrder(int id);
        Task<bool> CreateOrder(Orders order);
    }
}
