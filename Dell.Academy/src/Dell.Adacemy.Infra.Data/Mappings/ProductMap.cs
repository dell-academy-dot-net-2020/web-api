using Dell.Academy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Dell.Academy.Infra.Data.Mappings
{
            public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Description).HasMaxLength(20); ;
            builder.Property(c => c.Value).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Register).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Active).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Provider).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Category).IsRequired().HasMaxLength(15);
            builder.ToTable("Products");
        }
    }
}


