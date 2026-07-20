using EcommerceAPI.Entities;

namespace EcommerceAPI.Repositories.Interfaces
{
    public interface IEcommerceRepository
    {
        Task<List<Product>> GetProductsAsync(string? productName = null, decimal? minPrice = null, decimal? maxPrice = null, int page = 1, int pageSize = 10);
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product); Task DeleteProductAsync(Product product);
        Task UpdateProductAsync(Product product);

    }
}
