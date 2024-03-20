using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Response;
using OnlineShopApi.Repository.Interface;
using System.Threading.Tasks;

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

        public async Task<bool> EditCustomer(Customers customer)
        {   
            try
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

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }          
        }

        public async Task<bool> DeleteCustomer(int id)
        {        
            try
            {
                Customers order = await FindCustomer(id);
                this.context.Remove(order);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> CreateCustomer(Customers customer)
        {
            try
            {
                await this.context.Customers.AddAsync(customer);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

    }
}
