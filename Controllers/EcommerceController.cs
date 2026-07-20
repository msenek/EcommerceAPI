using Microsoft.AspNetCore.Mvc;
using EcommerceAPI.Services.Interfaces;
using EcommerceAPI.Models.DTOs;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EcommerceController : ControllerBase
    {
        private readonly IEcommerceService _service;
        public EcommerceController(IEcommerceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(string? productName = null, decimal? minPrice = null, decimal? maxPrice = null, int page = 1, int pageSize = 10)
        {
            var products = await _service.GetProductsAsync(productName, minPrice, maxPrice, page, pageSize);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDTO request)
        {
            var product = await _service.CreateProductAsync(request);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _service.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestDTO request)
        {
            await _service.UpdateProductAsync(id, request);
            return NoContent();
        }
    }
}