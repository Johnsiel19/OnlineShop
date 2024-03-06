using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Models;
using OnlineShopApi.Repository.Interface;

namespace OnlineShopApi.Controllers
{
    [ApiController]
    [Route("api/orders/")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet("getorders")]
        public async Task<ActionResult<List<Orders>>> GetOrders()
        {
            var funcion = await orderRepository.GetOrders();
            return funcion.ToList();
        }

        [HttpGet("getorderbyid/{id}")]
        public async Task<ActionResult<Orders>> GetOrderById(int id)
        {
            var funcion = await orderRepository.FindOrder(id);
            return funcion;
        }

        [HttpPost("createorder")]
        public async Task CreateOrder(Orders order)
        {
            await orderRepository.CreateOrder(order);
        }

        [HttpPut("editorder")]
        public async Task<ActionResult> EditOrder(Orders order)
        {
            await this.orderRepository.EditOrder(order);
            return NoContent();
        }

        [HttpDelete("deleteorder/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await orderRepository.DeleteOrder(id);
            return NoContent();
        }
    }
}

