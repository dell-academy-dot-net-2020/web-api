﻿using FluentValidation.Results;
using System.Net;

namespace Dell.Academy.Application.Extensions
{
    public class OperationResult
    {
        public object Content { get; private set; }
        public ValidationResult Result { get; private set; }
        public bool IsValid => Result?.IsValid ?? true;
        public HttpStatusCode StatusCode { get; private set; }

        public OperationResult(ValidationResult result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }

        public OperationResult(object content) => Content = content;
    }
}