using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Models;
using OnlineShopApi.Repository.Interface;

namespace OnlineShopApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly OnlineShopContext context;
        public CustomerRepository(OnlineShopContext context)
        {
            this.context = context;
        }

        public async Task<List<Customers>> GetCustomers()
        {
            return await this.context.Customers.ToListAsync();
        }

        public async Task<Customers> FindCustomer(int customerid)
        {
            var query = await this.context.Customers.FirstOrDefaultAsync(row => row.CustomerId == customerid);
            return query;
        }

        public async Task EditCustomer(Customers customer)
        {
            Customers c = await FindCustomer(customer.CustomerId);
            c.Name = customer.Name;
            c.Lastname = customer.Lastname;
            c.Email = customer.Email;
            c.Phone = customer.Phone;
            c.Direccion = customer.Direccion;
            c.ClientType = customer.ClientType;
            c.Date = DateTime.Now;
            c.Password = customer.Password;

            this.context.SaveChanges();
        }

        public async Task DeleteCustomer(int id)
        {
            Customers order = await FindCustomer(id);
            this.context.Remove(order);
            this.context.SaveChanges();
        }

        public async Task CreateCustomer(Customers customer)
        {
            await this.context.Customers.AddAsync(customer);
            await this.context.SaveChangesAsync();
        }
    }
}
