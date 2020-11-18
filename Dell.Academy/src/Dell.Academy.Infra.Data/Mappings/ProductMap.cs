﻿using Dell.Academy.Domain.Models;
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
            builder.Property(c => c.Description).HasMaxLength(30);
            builder.Property(c => c.Value).IsRequired();
            builder.Property(c => c.Register).IsRequired();
            builder.Property(c => c.Active);
            builder.HasOne(c => c.Provider).WithMany(p => p.Products).HasForeignKey(c => c.ProviderId);
            builder.HasOne(c => c.Category).WithMany(p => p.Products).HasForeignKey(c => c.CategoryId);
            builder.ToTable("Products");
        }
    }
}