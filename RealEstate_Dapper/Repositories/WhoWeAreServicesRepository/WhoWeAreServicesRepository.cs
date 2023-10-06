using Dapper;
using RealEstate_Dapper.Dtos.WhoWeAreServicesDtos;
using RealEstate_Dapper.Models.DapperContext;

namespace RealEstate_Dapper.Repositories.WhoWeAreServicesRepository
{
    public class WhoWeAreServicesRepository : IWhoWeAreServicesRepository
    {
        private readonly Context _context;

        public WhoWeAreServicesRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreServicesDto(CreateWhoWeAreServicesDto createWhoWeAreServicesDto)
        {
            string query = "INSERT INTO Service (ServiceName,ServiceStatus) VALUES (@serviceName,@serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", createWhoWeAreServicesDto.ServiceName);
            parameters.Add("@serviceStatus", true);
          
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreServicesDto(int id)
        {

            string query = "Delete From Service Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIDWhoWeAreServicesDto> getByIDWhoWeAreServicesDto(int id)
        {
            string query = "SELECT * FROM Service WHERE ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreServicesDto>(query, parameters);
                return values;
            }
        }

        public async  Task<List<ResultWhoWeAreServicesDto>> GetResultWhoWeAreServicesDtos()
        {
            string query = "SELECT * FROM Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreServicesDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateWhoWeAreServicesDto(UpdateWhoWeAreServicesDto updateWhoWeAreServicesDto)
        {
            var query = "UPDATE Service SET ServiceName=@serviceName,ServiceStatus=@serviceStatus WHERE ServiceID = @serviceID;";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", updateWhoWeAreServicesDto.StatusID);

            parameters.Add("@serviceName", updateWhoWeAreServicesDto.ServiceName);
            parameters.Add("@serviceStatus", true);
           




            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
