using System;

namespace Dell.Academy.Application.Extensions.Exceptions
{
    public class DatabaseCommitException : Exception
    {
        public DatabaseCommitException(string message) : base(message)
        {
        }
    }
}