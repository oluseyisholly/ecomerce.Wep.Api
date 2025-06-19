using System.Collections;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        User GetUsersById();
        Task<CreateUserDto> CreateUser(CreateUserDto createUserDto);
    }
}
