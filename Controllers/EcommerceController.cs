using EcommerceAPI.Models.DTOs;
using EcommerceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            
            return Ok(product);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDTO request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var product = await _service.CreateProductAsync(request, userId);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            
            var product = await _service.GetProductByIdAsync(id);
            await _service.DeleteProductAsync(id, userId);
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestDTO request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _service.UpdateProductAsync(id, request, userId);
            return NoContent();
        }
    }
}