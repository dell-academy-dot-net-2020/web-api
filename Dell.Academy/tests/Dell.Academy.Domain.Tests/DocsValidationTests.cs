using Dell.Academy.Domain.Models.Validations.Utils;
using Xunit;

namespace Dell.Academy.Domain.Tests
{
    public class DocsValidationTests
    {
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

            // Act

            // Assert
        }
    }
}