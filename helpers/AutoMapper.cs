using AutoMapper;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserDto>(); // Entity to DTO
            CreateMap<CreateUserDto, User>(); // DTO to Entity
        }
    }
}
