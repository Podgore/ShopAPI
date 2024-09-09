using AutoMapper;
using ShopAPI.Common.DTOs;
using ShopAPI.DAL.Entity;

namespace ShopAPI.BLL.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
