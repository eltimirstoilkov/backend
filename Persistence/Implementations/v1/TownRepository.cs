using Microsoft.EntityFrameworkCore;
using Persistence.Context.v1;
using Persistence.Entities.v1;
using Vehicles.Data.Interfaces.v1;

namespace Persistence.Implementations.v1
{
    public class TownRepository : ITownRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TownRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Town> GetAllAsync()
        {
            var towns = _dbContext.Towns.ToList();
            return null;
        }

        public async Task<Town> GetByIdAsync(Guid id)
        {
            var town = await _dbContext.Towns.FirstOrDefaultAsync(x => x.Id == id);
            return town;
        }

        public async Task<bool> IsExistingTownAsync(Guid id)
        {
            return await _dbContext.Towns.AnyAsync(x => x.Id == id);
        }

    }
}
