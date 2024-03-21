using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Models.Response;

namespace OnlineShopApi.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseModel>> GetProducts();

        Task<ProductResponseModel> FindProduct(int productId);

        Task<bool> EditProduct(ProductRequestModel customerRequestModel);

        Task<bool> DeleteProduct(int id);

        Task<bool> CreateProduct(ProductRequestModel customerRequestModel);
    }
}
