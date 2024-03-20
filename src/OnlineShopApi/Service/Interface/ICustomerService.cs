using OnlineShopApi.Models;
using OnlineShopApi.Models.Response;

namespace OnlineShopApi.Service.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerResponseModel>> GetCustomers();

        Task<CustomerResponseModel> FindCustomer(int customerid);

        Task<bool> EditCustomer(Customers customer);

        Task<bool> DeleteCustomer(int id);

        Task<bool> CreateCustomer(CustomerResponseModel customer);
    }
}