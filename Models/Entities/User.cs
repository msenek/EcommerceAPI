using System.ComponentModel.DataAnnotations;
using EcommerceAPI.Entities;
namespace EcommerceAPI.Models.Entities
{
    public class User

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

public List<Product> Products { get; set; }

    }
}
