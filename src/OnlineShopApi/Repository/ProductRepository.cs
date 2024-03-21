using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Models;
using OnlineShopApi.Repository.Interface;

namespace OnlineShopApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopContext context;

        public ProductRepository(OnlineShopContext context)
        {
            this.context = context;
        }

        public async Task<Products> FindProduct(int productId)
        {
            var query = await this.context.Products.FirstOrDefaultAsync(row => row.ProductId == productId);
            return query;
        }

        public async Task<bool> EditProduct(Products products)
        {
            try
            {
                Products p = await FindProduct(products.ProductId);
                p.Provider = products.Provider;
                p.PurchasPrice = products.PurchasPrice;
                p.SalePrice = products.SalePrice;
                p.CustomerId = products.CustomerId;
                p.Date = DateTime.Now;
                p.Description = products.Description;
                p.Name = products.Name;
                p.Stock = products.Stock;

                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                Products product = await FindProduct(id);
                this.context.Remove(product);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await this.context.Products.ToListAsync();
        }

        public async Task<bool> CreateProduct(Products products)
        {
            try
            {
                await this.context.Products.AddAsync(products);
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
