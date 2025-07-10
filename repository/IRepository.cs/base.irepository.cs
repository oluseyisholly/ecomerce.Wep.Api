using System.Linq.Expressions;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;

namespace EcommerceWebApi.IRepository
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<PaginatedResponse<T>> GetPaginatedAll(
            PaginationQuery query,
            params Expression<Func<T, object>>[] includes
        );
        Task<T?> GetById(int id);
        Task<T> Create(T data);
        Task<T> Update(T data);
        Task<T> Delete(T data);
    }
}
