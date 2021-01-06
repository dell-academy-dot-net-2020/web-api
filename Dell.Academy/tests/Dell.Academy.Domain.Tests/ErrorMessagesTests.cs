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
            var errorMessage = "Não foi possível salvar o registro no banco de dados";

            // Act
            var result = ErrorMessages.DatabaseCommitError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CategoryNameExistsError_ShouldReturnCategoryNameAlreadyExistsErrorMessage()
        {
            // Arrange
            var errorMessage = "Categoria já cadastrada";

            // Act
            var result = ErrorMessages.CategoryNameExistsError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void ProductSkuExistsError_ShouldReturnSkuExistsErrorMessage()
        {
            // Arrange
            var errorMessage = "Sku do produto já cadastrado";

            // Act
            var result = ErrorMessages.ProductSkuExistsError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void IdDoNotMatch_ShouldReturnIdDoNotMatchErrorMessage()
        {
            // Arrange
            var errorMessage = "Os Id's não correspondem";

            // Act
            var result = ErrorMessages.IdDoNotMatch;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CpfSizeError_ShouldReturnCpfSizeErrorMessage()
        {
            // Arrange
            var errorMessage = "O campo Cpf precisa ter 11 caracteres";

            // Act
            var result = ErrorMessages.CpfSizeError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CpfInvalidError_ShouldReturnInvalidCpfErrorMessage()
        {
            // Arrange
            var errorMessage = "O Cpf fornecido não é válido";

            // Act
            var result = ErrorMessages.CpfInvalidError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CnpjSizeError_ShouldReturnCnpjSizeErrorMessage()
        {
            // Arrange
            var errorMessage = "O campo Cnpj precisa ter 14 caracteres";

            // Act
            var result = ErrorMessages.CnpjSizeError;

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void CnpjInvalidError_ShouldReturnInvalidCnpjErrorMessage()
        {
            // Arrange
            var errorMessage = "O Cnpj fornecido não é válido";

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
            var errorMessage = $"Houve um erro durante a requisição: {exceptionMessage}";

            // Act
            var result = ErrorMessages.InternalServerError(exceptionMessage);

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void ProviderExistsError_ReceiveADocumentNumber_ShouldReturnAnProviderExistsErrorMessage()
        {
            // Arrange
            var documentNumber = "123.456.789-10";
            var errorMessage = $"Fornecedor com o documento {documentNumber} já está cadastrado";

            // Act
            var result = ErrorMessages.ProviderExistsError(documentNumber);

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void IntegrityReferenceError_ReceiveAnEntityType_ShouldReturnAnIntegrityReferenceErrorMessage()
        {
            // Arrange
            var entityType = "EntityTest";
            var errorMessage = $"Não foi possível exluir: {entityType} possui produtos cadastrados";

            // Act
            var result = ErrorMessages.IntegrityReferenceError(entityType);

            // Assert
            Assert.Equal(errorMessage, result);
        }

        [Fact]
        public void NotFoundError_ReceiveAnEntityTypeAndId_ShouldReturnANotFoundErrorMessage()
        {
            // Arrange
            var entityType = "EntityTest";
            var id = 1;
            var errorMessage = $"{entityType} com o id {id} não foi encontrado(a)";

            // Act
            var result = ErrorMessages.NotFoundError(entityType, id);

            // Assert
            Assert.Equal(errorMessage, result);
        }
    }
}