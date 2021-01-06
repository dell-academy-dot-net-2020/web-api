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
        public void CategoryNameExistsError_ShouldReturnTheCommitErrorMessage()
        {
            // Arrange
            var errorMessage = "Categoria j� cadastrada.";

            // Act
            var result = ErrorMessages.CategoryNameExistsError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void ProductSkuExistsError_ShouldReturnTheCommitErrorMessage()
        {
            // Arrange
            var errorMessage = "Sku do produto j� cadastrado.";

            // Act
            var result = ErrorMessages.ProductSkuExistsError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void IdDoNotMatch_ShouldReturnTheCommitErrorMessage()
        {
            // Arrange
            var errorMessage = "Os Id's n�o correspondem.";

            // Act
            var result = ErrorMessages.IdDoNotMatch;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CpfSizeError_ShouldReturnTheCommitErrorMessage()
        {
            // Arrange
            var errorMessage = "O campo Cpf precisa ter 11 caracteres.";

            // Act
            var result = ErrorMessages.CpfSizeError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CpfInvalidError_ShouldReturnTheCommitErrorMessage()
        {
            // Arrange
            var errorMessage = "O Cpf fornecido n�o � v�lido.";

            // Act
            var result = ErrorMessages.CpfInvalidError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CnpjSizeError_ShouldReturnTheCommitErrorMessage()
        {
            // Arrange
            var errorMessage = "O campo Cnpj precisa ter 14 caracteres.";

            // Act
            var result = ErrorMessages.CnpjSizeError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CnpjInvalidError_ShouldReturnTheCommitErrorMessage()
        {
            // Arrange
            var errorMessage = "O Cnpj fornecido n�o � v�lido.";

            // Act
            var result = ErrorMessages.CnpjInvalidError;

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

        [Fact]
        public void ProviderExistsError_ReceiveAnExceptionMessage_ShouldReturnAnProviderExistsErrorMessage()
        {
            // Arrange
            var exceptionMessage = "Exception message test";
            var errorMessage = $"Fornecedor com o documento {exceptionMessage}";

            // Act
            var result = ErrorMessages.ProviderExistsError(exceptionMessage);

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void IntegrityReferenceError_ReceiveAnExceptionMessage_ShouldReturnAnIntegrityReferenceErrorMessage()
        {
            // Arrange
            var exceptionMessage = "Exception message test";
            var errorMessage = $"N�o foi poss�vel exluir: {exceptionMessage}";

            // Act
            var result = ErrorMessages.IntegrityReferenceError(exceptionMessage);

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void NotFoundError_ReceiveAnExceptionMessage_ShouldReturnAnNotFoundErrorMessage()
        {
            // Arrange
            var exceptionMessage = "Exception message test";
            var errorMessage = $"n�o foi encontrado(a): {exceptionMessage}";

            // Act
            var result = ErrorMessages.NotFoundError(exceptionMessage);

            // Assert
            Assert.Equal(errorMessage, result);
        }
    }
}