using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Models;
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
        public async Task<ActionResult<List<OrdersResponseModel>>> GetOrders()
        {
            var funcion = await orderService.GetOrders();
            return funcion.ToList();
        }

        [HttpGet("getorderbyid/{id}")]
        public async Task<ActionResult<OrdersResponseModel>> GetOrderById(int id)
        {
            var funcion = await orderService.FindOrder(id);
            return funcion;
        }

        [HttpPost("createorder")]
        public async Task CreateOrder(Orders order)
        {
            await orderService.CreateOrder(order);
        }

        [HttpPut("editorder")]
        public async Task<ActionResult> EditOrder(Orders order)
        {
            await this.orderService.EditOrder(order);
            return NoContent();
        }

        [HttpDelete("deleteorder/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}

