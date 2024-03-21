using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Models;
using OnlineShopApi.Repository.Interface;

namespace OnlineShopApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineShopContext context;

        public OrderRepository(OnlineShopContext context)
        {
            this.context = context;
        }

        public async Task<Orders> FindOrder(int orderId)
        {
            var query = await this.context.Orders.FirstOrDefaultAsync(row => row.OrderId == orderId);
            return query;
        }

        public async Task<bool> EditOrder(Orders order)
        {
            try
            {
                Orders o = await FindOrder(order.OrderId);
                o.CustomerId = order.CustomerId;
                o.Date = order.Date;
                o.Total = order.Total;
                o.OrderDetails = order.OrderDetails;

                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }           
        }

        public async Task<bool> DeleteOrder(int id)
        {
            try
            {
                Orders order = await FindOrder(id);
                this.context.Remove(order);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateOrder(Orders order)
        {
            try
            {
                await this.context.Orders.AddAsync(order);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Orders>> GetOrders()
        {
            return await this.context.Orders.ToListAsync();
        }
    }
}
