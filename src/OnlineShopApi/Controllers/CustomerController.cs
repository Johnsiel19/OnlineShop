using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Models.Response;
using OnlineShopApi.Repository;
using OnlineShopApi.Repository.Interface;
using OnlineShopApi.Service.Interface;

namespace OnlineShopApi.Controllers
{
    [ApiController]
    [Route("api/customers/")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICustomerService customerService;

        public CustomerController( IMapper mapper, ICustomerService customerService)
        {
            this.mapper = mapper;
            this.customerService = customerService;
        }

        [HttpGet("getcustomers")]
        public async Task<ActionResult<List<CustomerResponseModel>>> GetCustomers()
        {
            var responses = await this.customerService.GetCustomers();
            return responses.ToList();
        }

        [HttpGet("getcustomerbyid/{id}")]
        public async Task<ActionResult<CustomerResponseModel>> GetCustomerById(int id)
        {
            var response = await this.customerService.FindCustomer(id);
            return response;
        }

        [HttpPost("createcustomer")]
        public async Task<bool> CreateCustomer(CustomerRequestModel customer)
        {
            var response = await this.customerService.CreateCustomer(customer);
            return response;
        }

        [HttpPut("editcustomer")]
        public async Task<ActionResult<bool>> EditCustomer(CustomerRequestModel customer)
        {
            var response = await this.customerService.EditCustomer(customer);
            return response;
        }

        [HttpDelete("deletecustomer/{id}")]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            var response = await this.customerService.DeleteCustomer(id);
            return response;
        }
    }
}
