using Dell.Academy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dell.Academy.Infra.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.Name).IsUnique();
            builder.HasMany(c => c.Products).WithOne(p => p.Category).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Categories");
        }
    }
}