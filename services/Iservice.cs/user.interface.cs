using System.Collections;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        User GetUsersById();
        CreateUserDto CreateUser(CreateUserDto createUserDto);
    }
}
