using Dell.Academy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dell.Academy.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString($"DefaultConnection@{Environment.MachineName}") ??
                configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApiContext>(opt => opt.UseMySQL(connectionString));
        }
    }
}