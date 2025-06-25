using System.Collections;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IService
{
    public interface IUserService
    {
        Task<StandardResponse<List<User>>> GetAllUsers();
        User GetUsersById();
        Task<StandardResponse<CreateUserDto>> CreateUser(CreateUserDto createUserDto);

        Task<StandardResponse<PaginatedResponse<User>>> GetPaginatedAllUsers(PaginationQuery query);
    }
}
