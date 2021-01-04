using Dell.Academy.Domain.Extensions;
using System;
using Xunit;

namespace Dell.Academy.Domain.Tests
{
    public class ErrorMessagesTests
    {
        [Fact]
        public void DatabaseCommitError_ShouldReturnTheCommitErrorMessage()
        {
            // Arrange
            var errorMessage = "Não foi possível salvar o registro no banco de dados.";

            // Act
            var result = ErrorMessages.DatabaseCommitError;

            // Assert
            Assert.Equal(errorMessage, result);
        }
    }
}