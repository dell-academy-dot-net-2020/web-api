using Dell.Academy.Application.Extensions;
using Dell.Academy.Domain.Extensions;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Net;

namespace Dell.Academy.Application.Services
{
    public abstract class BaseService
    {
        public OperationResult Error(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure("", errorMessage) };
            return new OperationResult(new ValidationResult(failures), statusCode);
        }

        public OperationResult Error(ValidationResult validationResult) => new OperationResult(validationResult);

        public OperationResult Success(object obj = null) => new OperationResult(obj);

        public OperationResult Commit(bool result)
        {
            if (!result)
                return Error(ErrorMessages.DatabaseCommitError);

            return Success();
        }
    }
}