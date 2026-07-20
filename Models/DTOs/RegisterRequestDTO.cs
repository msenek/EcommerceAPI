using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models.DTOs
{
    public class RegisterRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
