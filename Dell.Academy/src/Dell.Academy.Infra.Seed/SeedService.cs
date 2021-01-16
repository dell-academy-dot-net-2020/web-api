using Dell.Academy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dell.Academy.Infra.CrossCutting.Seed
{
    public class SeedService : ISeedService
    {
        private readonly ApiContext _context;

        public SeedService(ApiContext context) => _context = context;

        public void Seed()
        {
            _context.Database.Migrate();
            if (_context.Categories.Any()) return;

            var entities = EntitiesFixture.GetMockedProviders();
            _context.AddRange(entities);
            _context.SaveChanges();
        }
    }
}