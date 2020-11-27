using System;
using System.Collections.Generic;

namespace Dell.Academy.Application.Extensions.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; private set; }

        public ValidationException(List<string> errors) => Errors = errors;
    }
}