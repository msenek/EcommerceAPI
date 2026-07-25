using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models.DTOs
{
    public class RegisterRequestDTO
    {
        [Required(ErrorMessage = "The user name is obligatory")]
        [MaxLength(50, ErrorMessage = "The user name can only be a maxium of 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The email is obligatory")]
        [EmailAddress(ErrorMessage = "The email adress is obligatory")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The password is obligatory")]
        [MinLength(5, ErrorMessage = "the password must have a minimum of 5 characters")]
        public string Password { get; set; }
    }
}
