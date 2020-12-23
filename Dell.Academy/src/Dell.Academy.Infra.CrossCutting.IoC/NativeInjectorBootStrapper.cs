using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.Services;
using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Infra.CrossCutting.Seed;
using Dell.Academy.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dell.Academy.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Domain Bus (Mediator)

            // Application

            // Domain - Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProviderService, ProviderService>();

            // Domain - Commands

            // Infra - Data
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();

            // Infra - Seed Data
            services.AddTransient<ISeedService, SeedService>();
        }
    }
}