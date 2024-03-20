using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Repository.Interface;
using OnlineShopApi.Service.Interface;

namespace OnlineShopApi.Service
{
    public class ProductService : IProductService
    {
        private readonly OnlineShopContext context;

        public ProductService(OnlineShopContext context)
        {
            this.context = context;
        }

        public async Task<List<Products>> GetProducts()
        {
            return await this.context.Products.ToListAsync();
        }

        public async Task<Products> FindProduct(int productId)
        {
            var query = await this.context.Products.FirstOrDefaultAsync(row => row.ProductId == productId);
            return query;
        }

        public async Task EditProduct(Products products)
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
        }

        public async Task DeleteProduct(int id)
        {
            Products product = await FindProduct(id);
            this.context.Remove(product);
            this.context.SaveChanges();
        }

        public async Task CreateProduct(Products products)
        {
            await this.context.Products.AddAsync(products);
            await this.context.SaveChangesAsync();
        }

        Task<List<CustomerRequestModel>> IProductService.GetProducts()
        {
            throw new NotImplementedException();
        }

        Task<CustomerRequestModel> IProductService.FindProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
