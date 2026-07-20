using EcommerceAPI.Data;
using EcommerceAPI.Entities;
using EcommerceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repositories
{
    public class EcommerceRepository : IEcommerceRepository
    {
        private readonly EcommerceDbContext _context;

        public EcommerceRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        //GET con pag y fil
        public async Task<List<Product>> GetProductsAsync(string? productName = null, decimal? minPrice = null, decimal? maxPrice = null, int page = 1, int pageSize = 10)
        {
            var query = _context.products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(productName))
            {
                query = query.Where(p => p.ProductName.Contains(productName));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        //GET ID
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.products.FindAsync(id);
        }

        //POST
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return product;

        }

        //DELETE
        public async Task DeleteProductAsync(Product product)
        {
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
        }

        //PUT
        public async Task UpdateProductAsync(Product product)
        {
            _context.products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}