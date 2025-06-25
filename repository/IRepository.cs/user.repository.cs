using System.Collections;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();

        Task<PaginatedResponse<User>> GetPaginatedAllUsers(PaginationQuery query);

        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);

        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(User user);
    }
}
