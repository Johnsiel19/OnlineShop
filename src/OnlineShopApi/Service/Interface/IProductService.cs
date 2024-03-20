using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;

namespace OnlineShopApi.Service.Interface
{
    public interface IProductService
    {
        Task<List<CustomerRequestModel>> GetProducts();

        Task<CustomerRequestModel> FindProduct(int productId);
        Task EditProduct(Products products);

        Task DeleteProduct(int id);

        Task CreateProduct(Products products);
    }
}
