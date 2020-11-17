using Dell.Academy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dell.Academy.Infra.Data.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ApiContext)));
            base.OnModelCreating(modelBuilder);
        }
    }
}