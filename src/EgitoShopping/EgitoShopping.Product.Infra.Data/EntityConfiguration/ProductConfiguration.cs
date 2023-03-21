using EgitoShopping.Product.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgitoShopping.Product.Infra.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Price).HasColumnName("price");
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.Description).HasColumnName("description");
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.UrlImage).HasColumnName("url_image");
        }
    }
}
