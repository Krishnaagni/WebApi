using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();

        Task<Region> GetRegionAsync(Guid id);

        Task<Region> AddRegionAsync(Region region);
    }
}
