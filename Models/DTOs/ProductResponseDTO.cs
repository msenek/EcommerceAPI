using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models.DTOs
{
    public class ProductResponseDTO
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }

    }
}
