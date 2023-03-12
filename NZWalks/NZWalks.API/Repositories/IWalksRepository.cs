using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalksRepository
    {
        IEnumerable<Walk> GetAll();

        Task<Walk> GetWalkAsync(Guid id);
    }
}
