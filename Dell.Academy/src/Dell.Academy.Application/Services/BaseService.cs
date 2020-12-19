using Dell.Academy.Application.Extensions;
using Dell.Academy.Domain.Extensions;
using Dell.Academy.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Net;

namespace Dell.Academy.Application.Services
{
    public abstract class BaseService
    {
        private ValidationResult _validationResult;

        protected OperationResult Error(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure("", errorMessage) };
            return new OperationResult(new ValidationResult(failures), statusCode);
        }

        protected OperationResult ValidationErrors() => new OperationResult(_validationResult);

        protected OperationResult Success(object obj = null) => new OperationResult(obj);

        protected OperationResult Commit(bool result)
        {
            if (!result)
                return Error(ErrorMessages.DatabaseCommitError);

            return Success();
        }

        protected bool EntityIsValid<TV, TE>(TV validator, TE entity) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var result = validator.Validate(entity);
            if (result.IsValid) return true;

            _validationResult = result;
            return false;
        }
    }
}