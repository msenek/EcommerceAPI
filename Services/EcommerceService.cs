using EcommerceAPI.Entities;
using EcommerceAPI.Models.DTOs;
using EcommerceAPI.Middleware;
using EcommerceAPI.Services.Interfaces;
using EcommerceAPI.Repositories.Interfaces;

namespace EcommerceAPI.Services
{
    public class EcommerceService : IEcommerceService
    {
        private readonly IEcommerceRepository _repository;

        public EcommerceService(IEcommerceRepository repository)
        {
            _repository = repository;
        }

        private static void ValidateProductRequest(ProductRequestDTO request)
        {
            if (request == null)
                throw new BadRequestException("Product request cannot be null");

            if (string.IsNullOrWhiteSpace(request.ProductName))
                throw new BadRequestException("Product name is required");

            if (request.ProductName.Length < 3)
                throw new BadRequestException("Product name must be at least 3 characters");

            if (request.ProductName.Length > 100)
                throw new BadRequestException("Product name cannot exceed 100 characters");

            if (request.Price <= 0)
                throw new BadRequestException("Product price must be greater than zero");

            if (request.Price > 1000000)
                throw new BadRequestException("Product price cannot exceed 1,000,000");

            if (!string.IsNullOrWhiteSpace(request.Description) && request.Description.Length > 500)
                throw new BadRequestException("Product description cannot exceed 500 characters");
        }

        private static void ValidateId(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid product ID. ID must be greater than zero");
        }

        public async Task<List<Product>> GetProductsAsync(string? productName = null, decimal? minPrice = null, decimal? maxPrice = null, int page = 1, int pageSize = 10)
        {
            var products = await _repository.GetProductsAsync(productName, minPrice, maxPrice, page, pageSize);
 
            return products ?? new List<Product>();
            
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            ValidateId(id);

            var product = await _repository.GetProductByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"Product with ID {id} not found");

            return product;
        }

        public async Task<Product> CreateProductAsync(ProductRequestDTO request)
        {
            ValidateProductRequest(request);

            var product = new Product
            {
                ProductName = request.ProductName.Trim(),
                Description = request.Description.Trim(),
                Price = request.Price
            };

            return await _repository.CreateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            ValidateId(id);

            var product = await _repository.GetProductByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"Product with ID {id} not found");

            await _repository.DeleteProductAsync(product);
        }

        public async Task UpdateProductAsync(int id, ProductRequestDTO request)
        {
            ValidateId(id);
            ValidateProductRequest(request);

            var product = await _repository.GetProductByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"Product with ID {id} not found");

            product.ProductName = request.ProductName.Trim();
            product.Description = request.Description.Trim();
            product.Price = request.Price;

            await _repository.UpdateProductAsync(product);
        }
    }
}