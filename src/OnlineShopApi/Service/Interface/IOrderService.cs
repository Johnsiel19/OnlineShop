using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Models.Response;

namespace OnlineShopApi.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrders();

        Task<OrderResponseModel> FindOrder(int orderId);

        Task<bool> EditOrder(OrderRequestModel orderRequestModel);

        Task<bool> DeleteOrder(int id);

        Task<bool> CreateOrder(OrderRequestModel orderRequestModel);
    }
}
