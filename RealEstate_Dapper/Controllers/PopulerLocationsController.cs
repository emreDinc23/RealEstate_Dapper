using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.PopulerLocationDtos;
using RealEstate_Dapper.Repositories.PopulerLocationRepositories;

namespace RealEstate_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulerLocationsController : ControllerBase
    {
        private readonly IPopulerLocationRepository _populerLocationRepository;

        public PopulerLocationsController(IPopulerLocationRepository populerLocationRepository)
        {
            _populerLocationRepository = populerLocationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPopulerLocations()
        {
            var ourServices = await _populerLocationRepository.GetPopulerLocation();
            return Ok(ourServices);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOurService(CreatePopulerLocationDto createPopulerLocation)
        {
            _populerLocationRepository.CreatePopulerLocationAsync(createPopulerLocation);
            return Ok("Servis Ekleme Başarılı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOurService(int id)
        {
            _populerLocationRepository.DeletePopulerLocationAsync(id);
            return Ok("Servis Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePopulerLocation(UpdatePopulerLocationDto updatePopulerLocation)
        {
            _populerLocationRepository.UpdatePopulerLocationAsync(updatePopulerLocation);
            return Ok("Kategori Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopulerLocation(int id)
        {
            var ourService = await _populerLocationRepository.GetByIDPopulerLocation(id);
            return Ok(ourService);
        }

    }
}
