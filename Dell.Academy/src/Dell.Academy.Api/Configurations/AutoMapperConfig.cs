using AutoMapper;
using Dell.Academy.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dell.Academy.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
            => services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));
    }
}