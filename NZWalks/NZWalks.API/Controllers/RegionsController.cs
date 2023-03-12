using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        [HttpGet]
        public IActionResult GetAllRegion()
        {

            var region = regionRepository.GetAll();

            var regionsDTO = new List<Models.DTO.Region>();
            //return DTO
            region.ToList().ForEach(regionItem =>
            {
                var regionDTO = new Models.DTO.Region()
                {
                    Id = regionItem.Id,
                    Code = regionItem.Code,
                    Name = regionItem.Name,
                    Lat = regionItem.Lat,
                    Long = regionItem.Long,
                    Population = regionItem.Population,
                    Area = regionItem.Area
                };
                regionsDTO.Add(regionDTO);
            });
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}", Name = "GetRegionAsync")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetRegionAsync(id);

            if (region == null)
            {
                return NotFound();
            }
        
                return Ok(region);
            
              
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion(Models.DTO.AddRegionRequest addRegionRequest)
        {
            var region = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population,
                Area = addRegionRequest.Area
            };
            region = await regionRepository.AddRegionAsync(region);



            var regionDTO = new Models.DTO.Region()
            {
                Code = region.Code,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population,
                Area = region.Area
            };
            return CreatedAtRoute("GetRegionAsync", new { id = regionDTO.Id }, new Models.DTO.Region());
            
            if(regionDTO == null)
            {
                return Ok(regionDTO);
            }
            return NotFound();
        }
    }
}
