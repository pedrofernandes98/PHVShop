using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHVShop.Catalog.API.Models;

namespace PHVShop.Catalog.API.Context.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(12,2)
                .IsRequired();

            builder.Property(x => x.ImageURL)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
