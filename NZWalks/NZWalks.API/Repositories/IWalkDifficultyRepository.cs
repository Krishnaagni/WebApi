using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkDifficultyRepository
    {
        IEnumerable<WalkDifficulty> GetAll();

        Task<WalkDifficulty> GetWalkDifficultyByIdAsync(Guid id);
    }
}
