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

            // Domain - Events

            // Domain - Commands

            // Infra - Data

            // Infra - Seed Data
        }
    }
}