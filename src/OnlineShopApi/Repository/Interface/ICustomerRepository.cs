using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Models.Response;

namespace OnlineShopApi.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customers>> GetCustomers();

        Task<Customers> FindCustomer(int customerid);

        Task<bool> DeleteCustomer(int id);

        Task<bool> CreateCustomer(Customers customer);

        Task<bool> EditCustomer(Customers customer);
    }
}