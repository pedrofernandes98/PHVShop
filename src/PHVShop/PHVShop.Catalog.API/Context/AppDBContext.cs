using Microsoft.EntityFrameworkCore;
using PHVShop.Catalog.API.Models;
using System.Data;

namespace PHVShop.Catalog.API.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions option) : base(option) { }

        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);

            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   CategoryId = 1,
                   Name = "Material Escolar",
               },
               new Category
               {
                   CategoryId = 2,
                   Name = "Acessórios",
               }
            );
            base.OnModelCreating(modelBuilder);
        }


    }
}
