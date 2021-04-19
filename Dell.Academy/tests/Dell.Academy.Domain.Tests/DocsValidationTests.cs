using Bogus;
using Bogus.Extensions.Brazil;
using Dell.Academy.Domain.Models.Validations.Utils;
using Xunit;

namespace Dell.Academy.Domain.Tests
{
    [Collection(nameof(DomainTestsCollection))]
    public class DocsValidationTests
    {
        private readonly Faker _faker;

        public DocsValidationTests(DomainFixture fixture) => _faker = fixture.Faker;

        [Fact]
        public void CpfValidation_ReceiveACpfNumberWithDiferentSize_ShouldReturnFalse()
        {
            // Arrange
            var cpfs = new string[] { "", "123456", "1234567891025" };

            // Act
            var result = CpfValidation.Validate(cpfs[0]) || CpfValidation.Validate(cpfs[1]) || CpfValidation.Validate(cpfs[2]);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CpfValidation_ReceiveAnInvalidCpfNumber_ShouldReturnFalse()
        {
            // Arrange
            var cpfs = new string[] { "55555555555", "15698569874", "11155544400" };

            // Act
            var result = CpfValidation.Validate(cpfs[0]) || CpfValidation.Validate(cpfs[1]) || CpfValidation.Validate(cpfs[2]);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CpfValidation_ReceiveAValidCpfNumber_ShouldReturnTrue()
        {
            // Arrange
            var cpf = _faker.Person.Cpf();

            // Act
            var result = CpfValidation.Validate(cpf);

            // Assert
            Assert.True(result);
        }

        // CNPJ

        [Fact]
        public void CnpjValidation_ReceiveACnpjNumberWithDiferentSize_ShouldReturnFalse()
        {
            // Arrange
            var cnpjs = new string[] { "", "123456789", "12345678910250987654321" };

            // Act
            var result = CnpjValidation.Validate(cnpjs[0]) || CnpjValidation.Validate(cnpjs[1]) || CnpjValidation.Validate(cnpjs[2]);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CnpjValidation_ReceiveAnInvalidcnpjNumber_ShouldReturnFalse()
        {
            // Arrange
            var cnpjs = new string[] { "55555555555555", "15698569874321", "11155544400000" };

            // Act
            var result = CnpjValidation.Validate(cnpjs[0]) || CpfValidation.Validate(cnpjs[1]) || CnpjValidation.Validate(cnpjs[2]);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CnpjValidation_ReceiveAValidCpfNumber_ShouldReturnTrue()
        {
            // Arrange
            var cnpj = _faker.Company.Cnpj();

            // Act
            var result = CnpjValidation.Validate(cnpj);

            // Assert
            Assert.True(result);
        }
    }
}