using Dell.Academy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dell.Academy.Infra.Data.Mappings
{
  
    public class ProviderMap : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(15);
            builder.Property(c => c.DocumentNumber).HasMaxLength(15);
            builder.Property(c => c.ProviderType).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Active).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Products).IsRequired().HasMaxLength(15);
            builder.ToTable("providers");
        }
    }
}


