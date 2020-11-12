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
            builder.Property(c => c.Street).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Number).HasMaxLength(15);
            builder.Property(c => c.Complement).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Cep).IsRequired().HasMaxLength(15);
            builder.Property(c => c.District).IsRequired().HasMaxLength(15);
            builder.Property(c => c.City).IsRequired().HasMaxLength(15);
            builder.Property(c => c.State).IsRequired().HasMaxLength(15);
            builder.ToTable("Addresses");
        }
    }
}




   