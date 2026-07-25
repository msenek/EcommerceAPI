using Microsoft.EntityFrameworkCore;
using EcommerceAPI.Models.Entities;
using EcommerceAPI.Entities;

namespace EcommerceAPI.Data
{
    public class EcommerceDbContext : DbContext
    
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
         public DbSet<Product> products { get; set; }
    }
}
