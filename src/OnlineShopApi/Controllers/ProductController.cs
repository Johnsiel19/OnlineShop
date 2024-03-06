using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Models;
using OnlineShopApi.Repository.Interface;

namespace OnlineShopApi.Controllers
{
    [ApiController]
    [Route("api/products/")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("getproducts")]
        public async Task<ActionResult<List<Products>>> GetCustomers()
        {
            var funcion = await productRepository.GetProducts();
            return funcion.ToList();
        }

        [HttpGet("getproductbyid/{id}")]
        public async Task<ActionResult<Products>> GetProductById(int id)
        {
            var funcion = await productRepository.FindProduct(id);
            return funcion;
        }

        [HttpPost("createproduct")]
        public async Task CreateProduct(Products product)
        {
            await productRepository.CreateProduct(product);
        }

        [HttpPut("editproduct")]
        public async Task<ActionResult> EditProduct(Products product)
        {
            await this.productRepository.EditProduct(product);
            return NoContent();
        }

        [HttpDelete("deleteproduct/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await productRepository.DeleteProduct(id);
            return NoContent();
        }


    }
}
