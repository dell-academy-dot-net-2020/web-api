using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Dell.Academy.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Dell Academy Api",
                Description = "Web Api for Dell Academy C#",
                Contact = new OpenApiContact
                {
                    Name = "Cleo",
                    Email = "cleo.silva@dellead.com",
                    Url = new Uri("http://leadfortaleza.com.br/portal"),
                },
                License = new OpenApiLicense
                {
                    Name = "Mit License",
                    Url = new Uri("https://opensource.org/licenses/MIT"),
                }
            }));
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dell Academy Api v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}