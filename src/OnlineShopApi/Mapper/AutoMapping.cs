using AutoMapper;
using OnlineShopApi.Models;
using OnlineShopApi.Models.Response;

namespace OnlineShopApi.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {
            CreateMap<CustomerResponseModel, Customers>();
        }
    }
}
