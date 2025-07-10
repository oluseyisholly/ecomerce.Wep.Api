using System.Linq.Expressions;
using AutoMapper;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class BaseRepository<T>(DbSet<T> __base, AppDbContext context, IMapper mapper)
        : IBaseRepository<T>
        where T : class
    {
        private readonly DbSet<T> _base = __base;
        private readonly IMapper _mapper = mapper;

        private readonly AppDbContext _context = context;

        public async Task<T> Create(T data)
        {
            _base.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<T> Update(T data)
        {
            _base.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<List<T>> GetAll()
        {
            return await _base.ToListAsync();
        }

        public async Task<PaginatedResponse<T>> GetPaginatedAll(
            PaginationQuery paginationQuery,
            params Expression<Func<T, object>>[] includes
        )
        {
            var baseQuery = _base.AsQueryable();

            IQueryable<T> query = baseQuery
                .Skip((paginationQuery.PageNumber - 1) * paginationQuery.PageSize)
                .Take(paginationQuery.PageSize);

            foreach (var include in includes)
            {
                query = baseQuery.Include(include);
            }

            var totalRecords = await baseQuery.CountAsync();

            var data = await query.ToListAsync();

            return new PaginatedResponse<T>(
                data,
                totalRecords,
                paginationQuery.PageNumber,
                paginationQuery.PageSize
            );
        }

        public async Task<T> Delete(T Base)
        {
            _base.Remove(Base);
            await _context.SaveChangesAsync();
            return Base;
        }

        public async Task<T?> GetById(int id)
        {
            return await _base.FindAsync(id);
        }
    }
}
