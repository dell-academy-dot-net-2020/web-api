using Dell.Academy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dell.Academy.Infra.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Street).IsRequired().HasMaxLength(30);
            builder.Property(c => c.Number).HasMaxLength(6);
            builder.Property(c => c.Complement).IsRequired(false).HasMaxLength(15);
            builder.Property(c => c.Cep).IsRequired().HasMaxLength(8);
            builder.Property(c => c.District).IsRequired().HasMaxLength(30);
            builder.Property(c => c.City).IsRequired().HasMaxLength(30);
            builder.Property(c => c.State).IsRequired().HasMaxLength(2);
            builder.HasOne(c => c.Provider).WithOne(p => p.Address).HasForeignKey<Address>(c => c.ProviderId);
            builder.ToTable("Addresses");
        }
    }
}