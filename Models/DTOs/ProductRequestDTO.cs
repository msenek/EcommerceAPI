using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models.DTOs
{
    public class ProductRequestDTO
    {
        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(800)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

       
    }
}
