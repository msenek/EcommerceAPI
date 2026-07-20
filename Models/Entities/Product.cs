using System.ComponentModel.DataAnnotations;
using EcommerceAPI.Models.Entities;
namespace EcommerceAPI.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(800)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
