using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Response;
using OnlineShopApi.Repository.Interface;
using OnlineShopApi.Service.Interface;

namespace OnlineShopApi.Service
{
    public class OrderService : IOrderService
    {
        private readonly OnlineShopContext context;

        public OrderService(OnlineShopContext context)
        {
            this.context = context;
        }

        public async Task<List<Orders>> GetOrders()
        {
            return await this.context.Orders.ToListAsync();
        }

        public async Task<Orders> FindOrder(int orderId)
        {
            var query = await this.context.Orders.FirstOrDefaultAsync(row => row.OrderId == orderId);
            return query;
        }

        public async Task EditOrder(Orders order)
        {
            Orders o = await FindOrder(order.OrderId);
            o.CustomerId = order.CustomerId;
            o.Date = order.Date;
            o.Total = order.Total;
            o.OrderDetails = order.OrderDetails;

            this.context.SaveChanges();
        }

        public async Task DeleteOrder(int id)
        {
            Orders order = await FindOrder(id);
            this.context.Remove(order);
            this.context.SaveChanges();
        }

        public async Task CreateOrder(Orders order)
        {
            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();
        }

        Task<List<OrdersResponseModel>> IOrderService.GetOrders()
        {
            throw new NotImplementedException();
        }

        Task<OrdersResponseModel> IOrderService.FindOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
