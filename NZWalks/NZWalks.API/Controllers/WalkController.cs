using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkController : Controller
    {
        private readonly IWalksRepository walksRepository;

        public WalkController(IWalksRepository walksRepository)
        {
            this.walksRepository = walksRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var walks = walksRepository.GetAll();

            var walksDTO = new List<Models.DTO.Walks>();

            walks.ToList().ForEach(walkItem =>
            {
                var walkDTO = new Models.DTO.Walks()
                {
                    Id = walkItem.Id,
                    Name = walkItem.Name,
                    Length = walkItem.Length,
                    RegionId = walkItem.RegionId,
                    WalkDifficultyId = walkItem.WalkDifficultyId
                };
                walksDTO.Add(walkDTO);
            });
            
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalk(Guid id)
        {
            var walk =  await walksRepository.GetWalkAsync(id);

            if (walk == null)
            {
                return NotFound();
            }
            return Ok(walk);
        }
    }

  


}
