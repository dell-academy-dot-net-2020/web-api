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
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.DocumentNumber).HasMaxLength(14);
            builder.HasIndex(c => c.DocumentNumber).IsUnique();
            builder.Property(c => c.ProviderType).IsRequired();
            builder.Property(c => c.Active);
            builder.HasOne(c => c.Address).WithOne(a => a.Provider).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Products).WithOne(p => p.Provider).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Providers");
        }
    }
}