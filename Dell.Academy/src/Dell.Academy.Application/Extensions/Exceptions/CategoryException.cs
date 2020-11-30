using System;

namespace Dell.Academy.Application.Extensions.Exceptions
{
    public class CategoryException : Exception
    {
        public CategoryException(string message) : base(message)
        {
        }
    }
}