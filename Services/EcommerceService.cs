using EcommerceAPI.Entities;
using EcommerceAPI.Middleware;
using EcommerceAPI.Models.DTOs;
using EcommerceAPI.Models.Entities;
using EcommerceAPI.Repositories.Interfaces;
using EcommerceAPI.Services.Interfaces;
using System.Security.Claims;

namespace EcommerceAPI.Services
{
    public class EcommerceService : IEcommerceService
    {
        private readonly IEcommerceRepository _repository;

        public EcommerceService(IEcommerceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponseDTO>> GetProductsAsync(string? productName = null, decimal? minPrice = null, decimal? maxPrice = null, int page = 1, int pageSize = 10)
        {
            var products = await _repository.GetProductsAsync(productName, minPrice, maxPrice, page, pageSize);

            return products.Select(p => new ProductResponseDTO
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price
            }).ToList();
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int id)
        {

            var product = await _repository.GetProductByIdAsync(id);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }
            return new ProductResponseDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price
            };
        }

        public async Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO request, int userId)
        {
            var product = new Product
            {
                ProductName = request.ProductName.Trim(),
                Description = request.Description.Trim(),
                Price = request.Price,
                UserId = userId
            };
            await _repository.CreateProductAsync(product);

            return new ProductResponseDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price
            };
        }

        public async Task DeleteProductAsync(int id, int userId)
        {
            var product = await _repository.GetProductByIdAsync(id);

            if (product.UserId != userId)
                throw new ConflictException("You can't delete another user's product.");

            await _repository.DeleteProductAsync(product);
        }

        public async Task<ProductResponseDTO> UpdateProductAsync(int id, ProductRequestDTO request, int userId)
        {
            
            var product = await _repository.GetProductByIdAsync(id)
              ?? throw new NotFoundException($"Product with ID {id} not found");

            if (product.UserId != userId)
                throw new ConflictException("You can't update another user's product.");

            product.ProductName = request.ProductName.Trim();
            product.Description = request.Description.Trim();
            product.Price = request.Price;

            await _repository.UpdateProductAsync(product);

            return new ProductResponseDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                
            };
        }
    }
}