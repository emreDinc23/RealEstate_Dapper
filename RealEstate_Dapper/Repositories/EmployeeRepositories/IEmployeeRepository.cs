using RealEstate_Dapper.Dtos.EmployeeDtos;

namespace RealEstate_Dapper.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetEmployeeAsync();
        void CreateEmployeeAsync(CreateEmployeeDto createEmployee);
        void UpdateEmployeeAsync(UpdateEmployeeDto updateEmployee);
        void DeleteEmployeeAsync(int id);
        Task<GetByIDEmployeeDto> GetEmployee(int id);
    }
}
