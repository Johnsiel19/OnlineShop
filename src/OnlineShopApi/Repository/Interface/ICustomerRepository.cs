using OnlineShopApi.Models;

namespace OnlineShopApi.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetCustomers();

        Task<Customers> FindCustomer(int customerid);

        Task EditCustomer(Customers customer);

        Task DeleteCustomer(int id);

        Task CreateCustomer(Customers customer);
    }
}