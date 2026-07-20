using EcommerceAPI.Entities;
using EcommerceAPI.Models.DTOs;

namespace EcommerceAPI.Services.Interfaces
{
    public interface IEcommerceService
    {
        Task<List<Product>> GetProductsAsync(string? productName = null, decimal? minPrice = null, decimal? maxPrice = null, int page = 1, int pageSize = 10);
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(ProductRequestDTO request);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(int id, ProductRequestDTO request);

    }
}
