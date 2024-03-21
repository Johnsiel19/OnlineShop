using AutoMapper;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
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

        public async Task<IEnumerable<CustomerResponseModel>> GetCustomers()
        {
            IEnumerable<Customers> responses = await this.customerRepository.GetCustomers();
            var Mapping = this.MapToResponseModelList(responses);

            return Mapping.ToList();
        }

        public async Task<CustomerResponseModel> FindCustomer(int customerid)
        {
            var responses = await this.customerRepository.FindCustomer(customerid);
            var mapping = this.MapToResponseModel(responses);
            return mapping;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var responses = await this.customerRepository.DeleteCustomer(id);
            return responses;
        }

        public async Task<bool> EditCustomer(CustomerRequestModel customerRequest)
        {
            var something = this.mapper.Map<Customers>(customerRequest);
            var responses = await this.customerRepository.CreateCustomer(something);

            return responses;

            //var mapping = this.MapToRequestModel(customerRequest);
            //var responses = await this.customerRepository.EditCustomer(mapping);

            //return responses;

        }

        public async Task<bool> CreateCustomer(CustomerRequestModel customerRequest)
        {
            var something = this.mapper.Map<Customers>(customerRequest);
            var responses = await this.customerRepository.CreateCustomer(something);

            return responses;
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

        private CustomerResponseModel MapToResponseModel(Customers customer)
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
            return responseModel;
        }

        private Customers MapToRequestModel(CustomerResponseModel customer)
        {
            Customers responseModel = new Customers()
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
            return responseModel;
        }       
    }
}
