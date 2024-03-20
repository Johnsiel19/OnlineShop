using OnlineShopApi.Models;

namespace OnlineShopApi.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<Products>> GetProducts();

        Task<Products> FindProduct(int productId);

        Task<bool> EditProduct(Products products);

        Task<bool> DeleteProduct(int id);

        Task<bool> CreateProduct(Products products);
    }
}
