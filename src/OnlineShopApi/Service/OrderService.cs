using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Models.Response;
using OnlineShopApi.Repository.Interface;
using OnlineShopApi.Service.Interface;

namespace OnlineShopApi.Service
{
    public class OrderService : IOrderService
    {

        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        public async Task<bool> EditOrder(OrderRequestModel orderRequestModel)
        {
            var something = this.mapper.Map<Orders>(orderRequestModel);
            var responses = await this.orderRepository.EditOrder(something);

            return responses;

        }

        public async Task<bool> CreateOrder(OrderRequestModel orderRequestModel)
        {
            var something = this.mapper.Map<Orders>(orderRequestModel);
            var responses = await this.orderRepository.CreateOrder(something);

            return responses;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrders()
        {
            try
            {
                IEnumerable<Orders> responses = await this.orderRepository.GetOrders();

                var Mapping = this.MapToResponseModelList(responses);

                return Mapping.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OrderResponseModel> FindOrder(int orderId)
        {
            var responses = await this.orderRepository.FindOrder(orderId);
            var mapping = this.MapToResponseModel(responses);
            return mapping;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var responses = await this.orderRepository.DeleteOrder(id);
            return responses;
        }

        private List<OrderResponseModel> MapToResponseModelList(IEnumerable<Orders> ordersEnumerable)
        {
            List<OrderResponseModel> responseModels = new List<OrderResponseModel>();

            foreach (Orders order in ordersEnumerable)
            {
                OrderResponseModel responseModel = new OrderResponseModel()
                {
                    CustomerId = order.CustomerId,
                    Date = order.Date,
                    OrderId = order.OrderId,
                    Total = order.Total
                };

                responseModels.Add(responseModel);
            }

            return responseModels;
        }

        private OrderResponseModel MapToResponseModel(Orders order)
        {
            OrderResponseModel responseModel = new OrderResponseModel()
            {
                CustomerId = order.CustomerId,
                Date = DateTime.Now,
                OrderId = order.OrderId,
                Total = order.Total
            };
            return responseModel;
        }

    }
}
