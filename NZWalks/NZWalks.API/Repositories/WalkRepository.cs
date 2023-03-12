using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalksRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        public IEnumerable<Walk> GetAll()
        {
            return nZWalksDbContext.Walks.ToList();
        }

        public async Task<Walk> GetWalkAsync(Guid id)
        {
            return await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
