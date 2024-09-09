using AutoMapper;
using ShopAPI.Common.DTOs;
using ShopAPI.DAL.Entity;

namespace ShopAPI.BLL.Profiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile() 
        {
            CreateMap<PurchaseDTO, Purchase>();
            CreateMap<Purchase, PurchaseDTO>();
            CreateMap<Purchase, PurchaseResponce>();
        }
    }
}
