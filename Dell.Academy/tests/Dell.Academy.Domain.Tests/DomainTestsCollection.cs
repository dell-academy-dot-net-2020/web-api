using Xunit;

namespace Dell.Academy.Domain.Tests
{
    [CollectionDefinition(nameof(DomainTestsCollection))]
    public class DomainTestsCollection : ICollectionFixture<DomainFixture>
    {
    }
}