using Dell.Academy.Api.Configurations;
using Dell.Academy.Infra.CrossCutting.IoC;
using Dell.Academy.Infra.CrossCutting.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dell.Academy.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // WebAPI Config
            services.AddControllers();

            // Setting DBContexts
            services.AddDatabaseConfiguration(Configuration);

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // Swagger Config
            services.AddSwaggerConfiguration();

            // Adding MediatR for Domain Events and Notifications

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfig(Configuration);

            // Native Logs
            services.AddLogging();

            services.AddCors(opt => opt.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedService service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                service.Seed();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseSwaggerSetup();
            app.UseRouting();
            app.UseAuthorization();
            app.UseExceptionHadlerMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}