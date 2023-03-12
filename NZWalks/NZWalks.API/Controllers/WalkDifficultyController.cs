using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var WalkDiff = walkDifficultyRepository.GetAll();
            return Ok(WalkDiff);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDifficulty(Guid id)
        {
            var walkdiff = await walkDifficultyRepository.GetWalkDifficultyByIdAsync(id);

            if (walkdiff== null)
            {
                return NotFound();
            }
            return Ok(walkdiff);
        }
    }
}
