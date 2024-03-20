using OnlineShopApi.Models;
using OnlineShopApi.Models.Response;

namespace OnlineShopApi.Service.Interface
{
    public interface IOrderService
    {
        Task<List<OrdersResponseModel>> GetOrders();
        Task<OrdersResponseModel> FindOrder(int orderId);
        Task EditOrder(Orders order);
        Task DeleteOrder(int id);
        Task CreateOrder(Orders order);
    }
}
