using OnlineShopApi.Models;
using OnlineShopApi.Models.Response;

namespace OnlineShopApi.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetCustomers();

        Task<Customers> FindCustomer(int customerid);

        Task<bool> EditCustomer(Customers customer);

        Task<bool> DeleteCustomer(int id);

        Task<bool> CreateCustomer(Customers customer);
    }
}