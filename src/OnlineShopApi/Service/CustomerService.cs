using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Response;
using OnlineShopApi.Repository.Interface;
using OnlineShopApi.Service.Interface;

namespace OnlineShopApi.Service
{
    public class CustomerService : ICustomerService
    {


        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }

        public async Task<List<CustomerResponseModel>> GetCustomers()
        {

            try
            {

                IEnumerable<Customers> responses = await this.customerRepository.GetCustomers();

                var Mapping = this.MapToResponseModelList(responses);

                return Mapping.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Customers> FindCustomer(int customerid)
        {
            var responses = await this.customerRepository.FindCustomer(customerid);
            return responses;
        }

        public async Task<bool> EditCustomer(Customers customer)
        {
            var responses = await this.customerRepository.EditCustomer(customer);
            return responses;


        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var responses = await this.customerRepository.DeleteCustomer(id);
            return responses;
        }

        public async Task<bool> CreateCustomer(CustomerResponseModel customer)
        {
            var something = this.mapper.Map<Customers>(customer);


            var responses = await this.customerRepository.CreateCustomer(something);

            return responses;

        }

        Task<CustomerResponseModel> ICustomerService.FindCustomer(int customerid)
        {
            throw new NotImplementedException();
        }

        private List<CustomerResponseModel> MapToResponseModelList(IEnumerable<Customers> customersEnumerable)
        {
            List<CustomerResponseModel> responseModels = new List<CustomerResponseModel>();

            foreach (Customers customer in customersEnumerable)
            {
                CustomerResponseModel responseModel = new CustomerResponseModel()
                {
                    ClientType = customer.ClientType,
                    CustomerId = customer.CustomerId,
                    Date = customer.Date,
                    Direccion = customer.Direccion,
                    Email = customer.Email,
                    Lastname = customer.Lastname,
                    Name = customer.Name,
                    Password = customer.Password,
                    Phone = customer.Phone
                };

                responseModels.Add(responseModel);
            }

            return responseModels;
        }


    }



}
