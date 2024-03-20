using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Repository.Interface;
using OnlineShopApi.Service.Interface;

namespace OnlineShopApi.Controllers
{
    [ApiController]
    [Route("api/products/")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("getproducts")]
        public async Task<ActionResult<List<CustomerRequestModel>>> GetCustomers()
        {
            var funcion = await productService.GetProducts();
            return funcion.ToList();
        }

        [HttpGet("getproductbyid/{id}")]
        public async Task<ActionResult<CustomerRequestModel>> GetProductById(int id)
        {
            var funcion = await productService.FindProduct(id);
            return funcion;
        }

        [HttpPost("createproduct")]
        public async Task CreateProduct(Products product)
        {
            await productService.CreateProduct(product);
        }

        [HttpPut("editproduct")]
        public async Task<ActionResult> EditProduct(Products product)
        {
            await this.productService.EditProduct(product);
            return NoContent();
        }

        [HttpDelete("deleteproduct/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await productService.DeleteProduct(id);
            return NoContent();
        }


    }
}
