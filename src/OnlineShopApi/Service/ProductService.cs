using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Request;
using OnlineShopApi.Models.Response;
using OnlineShopApi.Repository.Interface;
using OnlineShopApi.Service.Interface;

namespace OnlineShopApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var responses = await this.productRepository.DeleteProduct(id);
            return responses;
        }

        public async Task<ProductResponseModel> FindProduct(int productId)
        {
            var responses = await this.productRepository.FindProduct(productId);
            var mapping = this.MapToResponseModel(responses);

            return mapping;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProducts()
        {
            IEnumerable<Products> responses = await this.productRepository.GetProducts();
            var Mapping = this.MapToResponseModelList(responses);

            return Mapping.ToList();
        }

        public async Task<bool> EditProduct(ProductRequestModel customerRequestModel)
        {
            var something = this.mapper.Map<Products>(customerRequestModel);
            var responses = await this.productRepository.EditProduct(something);

            return responses;
        }

        public async Task<bool> CreateProduct(ProductRequestModel customerRequestModel)
        {

            var something = this.MapToRequestModel(customerRequestModel);
            something.Date = DateTime.Now;
            var responses = await this.productRepository.CreateProduct(something);

            return responses;
        }

        private List<ProductResponseModel> MapToResponseModelList(IEnumerable<Products> productsEnumerable)
        {
            List<ProductResponseModel> responseModels = new List<ProductResponseModel>();

            foreach (Products product in productsEnumerable)
            {
                ProductResponseModel responseModel = new ProductResponseModel()
                {
                    CustomerId = product.CustomerId,
                    Date = product.Date,
                    Name = product.Name,
                    Description = product.Description,
                    ProductId = product.ProductId,
                    Provider = product.Provider,
                    PurchasPrice = product.PurchasPrice,
                    SalePrice = product.SalePrice,
                    Stock = product.Stock
                };

                responseModels.Add(responseModel);
            }
            return responseModels;
        }

        private ProductResponseModel MapToResponseModel(Products products)
        {
            ProductResponseModel responseModel = new ProductResponseModel()
            {
                CustomerId = products.CustomerId,
                Date = products.Date,
                Name = products.Name,
                Description = products.Description,
                ProductId = products.ProductId,
                Provider = products.Provider,
                PurchasPrice = products.PurchasPrice,
                SalePrice = products.SalePrice,
                Stock = products.Stock
            };
            return responseModel;
        }

        private Products MapToRequestModel(ProductRequestModel products)
        {
            Products responseModel = new Products()
            {
                CustomerId = products.CustomerId,
                Date = products.Date,
                Name = products.Name,
                Description = products.Description,
                ProductId = products.ProductId,
                Provider = products.Provider,
                PurchasPrice = products.PurchasPrice,
                SalePrice = products.SalePrice,
                Stock = products.Stock
            };
            return responseModel;
        }
    }
}
