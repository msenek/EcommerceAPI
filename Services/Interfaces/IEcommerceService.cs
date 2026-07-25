using EcommerceAPI.Entities;
using EcommerceAPI.Models.DTOs;

namespace EcommerceAPI.Services.Interfaces
{
    public interface IEcommerceService
    {
        Task<List<ProductResponseDTO>> GetProductsAsync(string? productName = null, decimal? minPrice = null, decimal? maxPrice = null, int page = 1, int pageSize = 10);
        Task<ProductResponseDTO> GetProductByIdAsync(int id);
        Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO request, int userId);
        Task DeleteProductAsync(int id, int userId);
        Task<ProductResponseDTO> UpdateProductAsync(int id, ProductRequestDTO request, int userId);

    }
}
