using AutoMapper;
using ShopAPI.Common.DTOs;
using ShopAPI.DAL.Entity;

namespace ShopAPI.BLL.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile() 
        {
            CreateMap<ClientDTO, Client>();
            CreateMap<Client, ClientDTO>();
        }
    }
}
