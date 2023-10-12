using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        //ActiveEmployeeCount
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount() {
        
        return Ok(_statisticsRepository.ActiveCategoryCount());
        
        }
        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {

            return Ok(_statisticsRepository.ActiveEmployeeCount());

        }
        [HttpGet("ApartmenCount")]
        public IActionResult ApartmenCount()
        {

            return Ok(_statisticsRepository.ApartmenCount());

        }
        //AvarageProductPriceByRent
        [HttpGet("AvarageProductPriceByRent")]
        public IActionResult AvarageProductPriceByRent()
        {

            return Ok(_statisticsRepository.AvarageProductPriceByRent());

        }
        //AvarageProductPriceBySale
        [HttpGet("AvarageProductPriceBySale")]
        public IActionResult AvarageProductPriceBySale()
        {

            return Ok(_statisticsRepository.AvarageProductPriceBySale());

        }
        //AvarageRoomCount
        [HttpGet("AvarageRoomCount")]
        public IActionResult AvarageRoomCount()
        {

            return Ok(_statisticsRepository.AvarageRoomCount());

        }
        //CategoryCount
        
         [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {

            return Ok(_statisticsRepository.CategoryCount());

        }
        //CategoryNameByMaxProductCount
        [HttpGet("CategoryNameByMaxProductCount")]
        public IActionResult CategoryNameByMaxProductCount()
        {

            return Ok(_statisticsRepository.CategoryNameByMaxProductCount());

        }
        //CityNameByMaxProductCount
        [HttpGet("CityNameByMaxProductCount")]
        public IActionResult CityNameByMaxProductCount()
        {

            return Ok(_statisticsRepository.CityNameByMaxProductCount());

        }
        //DifferentCityCount
        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
        {

            return Ok(_statisticsRepository.DifferentCityCount());

        }
        //EmployeeNameByMaxProductCount
        [HttpGet("EmployeeNameByMaxProductCount")]
        public IActionResult EmployeeNameByMaxProductCount()
        {

            return Ok(_statisticsRepository.EmployeeNameByMaxProductCount());

        }
        //LastProductPrice
        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice()
        {

            return Ok(_statisticsRepository.LastProductPrice());

        }
        //NewestBuildingYear
        [HttpGet("NewestBuildingYear")]
        public IActionResult NewestBuildingYear()
        {

            return Ok(_statisticsRepository.NewestBuildingYear());

        }
        //OldestBuildingYear
        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear()
        {

            return Ok(_statisticsRepository.OldestBuildingYear());

        }
        //PasiveCategoryCount
        [HttpGet("PasiveCategoryCount")]
        public IActionResult PasiveCategoryCount()
        {

            return Ok(_statisticsRepository.PasiveCategoryCount());

        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {

            return Ok(_statisticsRepository.ProductCount());

        }
       
    }
}
