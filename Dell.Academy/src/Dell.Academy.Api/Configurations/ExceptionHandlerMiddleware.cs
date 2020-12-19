using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dell.Academy.Api.Configurations
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var error = ErrorMessages.InternalServerError(ex.Message);
                if (ex.GetType() == typeof(DbUpdateException))
                    error = HandleDbUpdateException(context);

                var errorViewModel = new ErrorViewModel(new List<string> { error });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorViewModel));
            }
        }

        public string HandleDbUpdateException(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var path = context.Request.Path;
            var entityType = string.Empty;
            if (path.Value.Contains("categorias")) entityType = "Categoria";
            else entityType = "Fornecedor";

            return ErrorMessages.IntegrityReferenceError(entityType);
        }
    }

    public static class ExceptionHadlerMiddlewareExtension
    {
        public static void UseExceptionHadlerMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}