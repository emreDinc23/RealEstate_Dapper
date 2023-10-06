using Dapper;

using RealEstate_Dapper.Dtos.OurServicesDtos;
using RealEstate_Dapper.Models.DapperContext;

namespace RealEstate_Dapper.Repositories.OurServicesRepository
{
    public class OurServicesRepository : IOurServicesRepository
    {
        private readonly Context _context;

        public OurServicesRepository(Context context)
        {
            _context = context;
        }

        public async void CreateOurServiceAsync(CreateOurServiceDto createOurServiceDto)
        {
            string query = "INSERT INTO OurServices (OurServiceTitle, OurServiceDescription, OurServiceIcon) VALUES (@ourServiceTitle, @ourServiceDescription, @ourServiceIcon)";
            var parameters = new DynamicParameters();
            parameters.Add("ourServiceTitle", createOurServiceDto.OurServiceTitle);
            parameters.Add("ourServiceDescription", createOurServiceDto.OurServiceDescription);
            parameters.Add("ourServiceIcon", createOurServiceDto.OurServiceIcon);



            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteOurServiceAsync(int id)
        {
            string query = "Delete From OurServices Where OurServiceID=@ourServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("ourServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<GetByIDOurServiceDto> GetOurService(int id)
        {
            string query = "SELECT * FROM OurServices WHERE OurServiceID=@ourServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("@ourServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDOurServiceDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultOurServiceDto>> GetOurServicesAsync()
        {
            string query = "SELECT * FROM OurServices";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultOurServiceDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateOurServiceAsync(UpdateOurServiceDto updateOurServiceDto)
        {
            var query = "UPDATE OurServices SET OurServiceTitle = @ourServiceTitle,OurServiceDescription= @ourServiceDescription,OurServiceIcon=@ourServiceIcon WHERE OurServiceID= @ourServiceID;";
            var parameters = new DynamicParameters();
            parameters.Add("ourServiceTitle", updateOurServiceDto.OurServiceTitle);
            parameters.Add("ourServiceDescription", updateOurServiceDto.OurServiceDescription);
            parameters.Add("ourServiceIcon", updateOurServiceDto.OurServiceIcon);
            parameters.Add("ourServiceID", updateOurServiceDto.OurServiceID);



            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
