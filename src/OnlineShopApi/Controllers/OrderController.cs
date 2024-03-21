using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Models.Response;
using OnlineShopApi.Repository.Interface;
using OnlineShopApi.Service.Interface;

namespace OnlineShopApi.Controllers
{
    [ApiController]
    [Route("api/orders/")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("getorders")]
        public async Task<ActionResult<List<OrderResponseModel>>> GetOrders()
        {
            var responses = await this.orderService.GetOrders();
            return responses.ToList();
        }

        [HttpGet("getorderbyid/{id}")]
        public async Task<ActionResult<OrderResponseModel>> GetOrderById(int id)
        {
            var responses = await this.orderService.FindOrder(id);
            return responses;
        }

        [HttpPost("createorder")]
        public async Task<bool> CreateOrder(OrderRequestModel order)
        {
            var response = await this.orderService.CreateOrder(order);
            return response;
        }

        [HttpPut("editorder")]
        public async Task<ActionResult<bool>> EditOrder(OrderRequestModel order)
        {
            var response = await this.orderService.EditOrder(order);
            return response;
        }

        [HttpDelete("deleteorder/{id}")]
        public async Task<ActionResult<bool>> DeleteOrder(int id)
        {
            var response = await this.orderService.DeleteOrder(id);
            return response;
        }
    }
}

