using Dell.Academy.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dell.Academy.Api.Configurations
{
    public class ExceptionHanddlerMiddelware
    {
        private readonly RequestDelegate _next;

        public ExceptionHanddlerMiddelware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var error = $"Houve um erro durante a requisição: {ex.Message}";
                var errorViewModel = new ErrorViewModel(new List<string> { error });
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json; charset=utf-8";
                await context.Response.WriteAsync(error, Encoding.UTF8);
                await _next(context);
            }
        }
    }
}