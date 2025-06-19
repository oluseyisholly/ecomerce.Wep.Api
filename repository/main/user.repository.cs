using EcommerceWebApi.Data;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // void IUserRepository.CreateUser()
        // {
        //     throw new NotImplementedException();
        // }

        Task<User> IUserRepository.GetUserById()
        {
            throw new NotImplementedException();
        }
    }
}
