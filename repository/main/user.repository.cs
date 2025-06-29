using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dto;
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

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<PaginatedResponse<User>> GetPaginatedAllUsers(PaginationQuery query)
        {
            var baseQuery = _context.Users.AsQueryable();

            var totalRecords = await baseQuery.CountAsync();

            var users = await baseQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedResponse<User>(
                users,
                totalRecords,
                query.PageNumber,
                query.PageSize
            );
        }

        public async Task<User> DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
