using Microsoft.EntityFrameworkCore;
using Solid.Data.Entities;

namespace webShop.Entities
{
    public class ShopDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-783IDMP\\SQLEXPRESS;Database=MyShop_db;Integrated Security=True;TrustServerCertificate=True");
        }
        //public ShopDBContext(DbContextOptions<ShopDBContext> options):base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
