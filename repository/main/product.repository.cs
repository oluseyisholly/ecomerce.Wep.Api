using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<PaginatedResponse<Product>> GetPaginatedAllProducts(PaginationQuery query)
        {
            var baseQuery = _context.Products.AsQueryable();

            var totalRecords = await baseQuery.CountAsync();

            var Products = await baseQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedResponse<Product>(
                Products,
                totalRecords,
                query.PageNumber,
                query.PageSize
            );
        }

        public async Task<Product> DeleteUser(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
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
