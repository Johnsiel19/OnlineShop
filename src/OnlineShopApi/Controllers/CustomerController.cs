using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Models;
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
            var funcion = await customerService.GetCustomers();
            return funcion.ToList();
        }

        [HttpGet("getcustomerbyid/{id}")]
        public async Task<ActionResult<CustomerResponseModel>> GetCustomerById(int id)
        {
            var funcion = await customerService.FindCustomer(id);
            return funcion;
        }

        [HttpPost("createcustomer")]
        public async Task CreateCustomer(CustomerResponseModel customer)
        {
            await customerService.CreateCustomer(customer);
        }

        [HttpPut("editcustomer")]
        public async Task<ActionResult> EditCustomer(Customers customer)
        {
            await this.customerService.EditCustomer(customer);
            return NoContent();
        }

        [HttpDelete("deletecustomer/{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await customerService.DeleteCustomer(id);
            return NoContent();
        }


    }
}
