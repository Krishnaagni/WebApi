using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public IEnumerable<WalkDifficulty> GetAll()
        {
            return nZWalksDbContext.WalkDifficulty.ToList();
        }

        public async Task<WalkDifficulty> GetWalkDifficultyByIdAsync(Guid id)
        {
           return await nZWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
