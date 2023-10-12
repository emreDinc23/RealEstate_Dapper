using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Dtos.EmployeeDtos;
using RealEstate_Dapper.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository EmployeeRepository;
        public EmployeeController(IEmployeeRepository EmployeeRepository)
        {
            this.EmployeeRepository = EmployeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var Employee = await EmployeeRepository.GetEmployeeAsync();
            return Ok(Employee);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            EmployeeRepository.CreateEmployeeAsync(createEmployeeDto);
            return Ok("Personel Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            EmployeeRepository.UpdateEmployeeAsync(updateEmployeeDto);
            return Ok("Personel Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            EmployeeRepository.DeleteEmployeeAsync(id);
            return Ok("Personel Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var Employee = await EmployeeRepository.GetEmployee(id);
            return Ok(Employee);
        }
    }
}
