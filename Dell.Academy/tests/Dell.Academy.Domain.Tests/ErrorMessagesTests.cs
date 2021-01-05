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
            var errorMessage = "N�o foi poss�vel salvar o registro no banco de dados.";

            // Act
            var result = ErrorMessages.DatabaseCommitError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void InternalServerError_ReceiveAnExceptionMessage_ShouldReturnAnInternalServerErrorMessage()
        {
            // Arrange
            var exceptionMessage = "Exception message test";
            var errorMessage = $"Houve um erro durante a requisi��o: {exceptionMessage}";

            // Act
            var result = ErrorMessages.InternalServerError(exceptionMessage);

            // Assert
            Assert.Equal(errorMessage, result);
        }
    }
}