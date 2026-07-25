using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models.DTOs
{
    public class ProductRequestDTO
    {
       
        public string ProductName { get; set; }

       
        public string Description { get; set; }

      
        public decimal Price { get; set; }


       
    }
}
