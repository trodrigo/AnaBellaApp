using Microsoft.EntityFrameworkCore;

namespace AnaBellaApp.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Bermudas",
                Description = "Bermudas em geral"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "Camisetas e Blusas",
                Description = "Camisetas e blusas em geral"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Bermuda linho",
                Price = new decimal(69.9),
                Description = "Bermuda linho com elastano. Tamanho 40 ao 48",
                CategoryId = 1,
                ImageURL = "https://github.com/trodrigo/AnaBellaApp/blob/master/AnaBellaImages/bermuda_linho_elastano.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Blusa canelada",
                Price = new decimal(69.9),
                Description = "Blusa canelada com manga tamanho único regular",
                CategoryId = 2,
                ImageURL = "https://github.com/trodrigo/AnaBellaApp/blob/master/AnaBellaImages/blusa_canelada.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Regata canelada",
                Price = new decimal(69.9),
                Description = "Regata canelada com manga tamanho único regular",
                CategoryId = 2,
                ImageURL = "https://github.com/trodrigo/AnaBellaApp/blob/master/AnaBellaImages/regata_canelada.jpg"
            });
        }
    }
}
