using Dapper;
using RealEstate_Dapper.Dtos.EmployeeDtos;
using RealEstate_Dapper.Dtos.OurServicesDtos;
using RealEstate_Dapper.Models.DapperContext;

namespace RealEstate_Dapper.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployeeAsync(CreateEmployeeDto createEmployee)
        {
            string query = "INSERT INTO Employee (Name, Title, Mail,PhoneNumber,ImageUrl,Status) VALUES (@name, @title, @mail,@phoneNumber,@imageUrl,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("name", createEmployee.Name);
            parameters.Add("title", createEmployee.Title);
            parameters.Add("mail", createEmployee.Mail);
            parameters.Add("phoneNumber", createEmployee.PhoneNumber);
            parameters.Add("imageUrl", createEmployee.ImageUrl);

            parameters.Add("status", true);




            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployeeAsync(int id)
        {

            string query = "Delete From Employee Where EmployeeID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {

            string query = "SELECT * FROM Employee WHERE EmployeeID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultEmployeeDto>> GetEmployeeAsync()
        {
            string query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateEmployeeAsync(UpdateEmployeeDto updateEmployee)
        {
            var query = "UPDATE Employee SET Name= @name,Title= @title,Mail=@mail,PhoneNumber=@phoneNumber,ImageUrl=@imageUrl,Status=@status WHERE EmployeeID= @id;";
            var parameters = new DynamicParameters();

            parameters.Add("name", updateEmployee.Name);
            parameters.Add("title", updateEmployee.Title);
            parameters.Add("mail", updateEmployee.Mail);
            parameters.Add("phoneNumber", updateEmployee.PhoneNumber);            
            parameters.Add("imageUrl", updateEmployee.ImageUrl);

            parameters.Add("id", updateEmployee.EmployeeID);

            parameters.Add("status", true);




            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
