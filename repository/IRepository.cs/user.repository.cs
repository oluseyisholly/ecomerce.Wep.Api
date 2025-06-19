using System.Collections;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById();
        Task<User> CreateUser(User user);
    }
}
