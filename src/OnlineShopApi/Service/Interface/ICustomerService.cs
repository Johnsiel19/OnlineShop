using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Models.Response;

namespace OnlineShopApi.Service.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseModel>> GetCustomers();

        Task<CustomerResponseModel> FindCustomer(int customerid);

        Task<bool> EditCustomer(CustomerRequestModel customerRequest);

        Task<bool> DeleteCustomer(int id);

        Task<bool> CreateCustomer(CustomerRequestModel customerRequest);
    }
}