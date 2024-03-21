using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Models.Response;
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
        public async Task<ActionResult<List<ProductResponseModel>>> GetCustomers()
        {
            var response = await productService.GetProducts();
            return response.ToList();
        }

        [HttpGet("getproductbyid/{id}")]
        public async Task<ActionResult<ProductResponseModel>> GetProductById(int id)
        {
            var response = await productService.FindProduct(id);
            return response;
        }

        [HttpPost("createproduct")]
        public async Task<bool> CreateProduct(ProductRequestModel product)
        {
            var response = await productService.CreateProduct(product);
            return response;
        }

        [HttpPut("editproduct")]
        public async Task<ActionResult<bool>> EditProduct(ProductRequestModel product)
        {
            var response = await this.productService.EditProduct(product);
            return response;
        }

        [HttpDelete("deleteproduct/{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            var response = await productService.DeleteProduct(id);
            return response;
        }
    }
}
