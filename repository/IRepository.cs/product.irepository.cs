using System.Collections;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.IRepository
{
    public interface IProductRepository
    {
        Task<List<User>> GetAllProducts();

        Task<PaginatedResponse<Product>> GetPaginatedAllProducts(PaginationQuery query);

        Task<Product?> GetProductById(int id);
        Task<Product?> GetProductByEmail(string email);

        Task<Product> CreateProduct(Product Product);
        Task<Product> UpdateProduct(Product Product);
        Task<Product> DeleteProduct(User user);
    }
}
