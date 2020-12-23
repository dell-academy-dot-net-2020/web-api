using Dell.Academy.Infra.Data.Context;
using System.Linq;

namespace Dell.Academy.Infra.CrossCutting.Seed
{
    public class SeedService : ISeedService
    {
        private readonly ApiContext _context;

        public SeedService(ApiContext context) => _context = context;

        public void Seed()
        {
            if (_context.Categories.Any()) return;

            var entities = EntitiesFixture.GetMockedProviders();
            _context.AddRange(entities);
            _context.SaveChanges();
        }
    }
}