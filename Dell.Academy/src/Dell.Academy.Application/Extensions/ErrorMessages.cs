using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Dell.Academy.Application.Extensions
{
    public static class ErrorMessages
    {
        public static string NotFoundError(string entityType, long id) => $"{entityType} com o id {id} não foi encontrado(a)";

        public static List<string> ValidationErrors(ValidationResult validationResult)
            => validationResult.Errors.Select(e => e.ErrorMessage).ToList();
    }
}