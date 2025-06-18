using System.Collections;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IRepository
{
    public interface IUserRepository
    {
        Task<IList<User>> GetAllUsers();
        Task<User> GetUserById();
        void CreateUser(User user);
    }
}
