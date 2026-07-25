namespace EcommerceAPI.Models.DTOs
{
    public class AuthResponseDto
    {
       public int UserId { get; set; }
       public string Name { get; set; }
       public string Email { get; set; }
       public string AccessToken { get; set; }
    }
}
