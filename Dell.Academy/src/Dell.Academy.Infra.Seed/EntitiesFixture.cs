using Bogus;
using Bogus.Extensions.Brazil;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Enums;
using System.Collections.Generic;

namespace Dell.Academy.Infra.CrossCutting.Seed
{
    public static class EntitiesFixture
    {
        public static List<Provider> GetMockedProviders()
        {
            var faker = GetFaker<Provider>();
            var companyProviders = faker.CustomInstantiator(f =>
                new Provider(
                    f.Company.CompanyName(),
                    f.Company.Cnpj(),
                    ProviderType.Company,
                    f.Random.Bool(),
                    GetMockedAddress(),
                    GetMockProducts(GetMockedCategory())
                )).Generate(2);

            var personProviders = faker.CustomInstantiator(f =>
                new Provider(
                    f.Company.CompanyName(),
                    f.Person.Cpf(),
                    ProviderType.Person,
                    f.Random.Bool(),
                    GetMockedAddress(),
                    GetMockProducts(GetMockedCategory())
                )).Generate(3);

            var providers = new List<Provider>();
            providers.AddRange(companyProviders);
            providers.AddRange(personProviders);

            return providers;
        }

        private static List<Product> GetMockProducts(Category category)
        {
            var faker = GetFaker<Product>();
            var products = faker.CustomInstantiator(f =>
               new Product(
                   f.Commerce.ProductName(),
                   f.Commerce.ProductDescription(),
                   decimal.Parse(f.Commerce.Price()),
                   f.Random.Bool(),
                   f.Commerce.Random.AlphaNumeric(6),
                   0,
                   0,
                   category
               )).Generate(5);

            return products;
        }

        private static Category GetMockedCategory()
        {
            var faker = GetFaker<Category>();
            var category = faker.CustomInstantiator(f =>
                new Category(
                    f.Commerce.Categories(1)[0]
                )).Generate();

            return category;
        }

        private static Faker<TEntity> GetFaker<TEntity>() where TEntity : BaseEntity
            => new Faker<TEntity>("pt_BR");

        private static Address GetMockedAddress()
        {
            var faker = GetFaker<Address>();
            var address = faker.CustomInstantiator(f =>
                new Address(
                    f.Address.StreetName(),
                    int.Parse(f.Address.BuildingNumber()),
                    f.Address.SecondaryAddress(),
                    f.Address.ZipCode(),
                    f.Address.OrdinalDirection(),
                    f.Address.City(),
                    f.Address.StateAbbr()
                ));

            return address;
        }
    }
}