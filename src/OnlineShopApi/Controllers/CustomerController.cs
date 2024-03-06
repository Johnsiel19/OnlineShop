using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Models;
using OnlineShopApi.Repository;
using OnlineShopApi.Repository.Interface;

namespace OnlineShopApi.Controllers
{
    [ApiController]
    [Route("api/customers/")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        [HttpGet("getcustomers")]
        public async Task<ActionResult<List<Customers>>> GetCustomers()
        {
            var funcion = await customerRepository.GetCustomers();
            return funcion.ToList();
        }

        [HttpGet("getcustomerbyid/{id}")]
        public async Task<ActionResult<Customers>> GetCustomerById(int id)
        {
            var funcion = await customerRepository.FindCustomer(id);
            return funcion;
        }

        [HttpPost("createcustomer")]
        public async Task CreateCustomer(Customers customer)
        {
            await customerRepository.CreateCustomer(customer);
        }

        [HttpPut("editcustomer")]
        public async Task<ActionResult> EditCustomer(Customers customer)
        {
            await this.customerRepository.EditCustomer(customer);
            return NoContent();
        }

        [HttpDelete("deletecustomer/{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await customerRepository.DeleteCustomer(id);
            return NoContent();
        }


    }
}
