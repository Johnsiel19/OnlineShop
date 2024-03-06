using OnlineShopApi.Models;

namespace OnlineShopApi.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<Products>> GetProducts();

        Task<Products> FindProduct(int productId);
        Task EditProduct(Products products);

        Task DeleteProduct(int id);

        Task CreateProduct(Products products);
    }
}
