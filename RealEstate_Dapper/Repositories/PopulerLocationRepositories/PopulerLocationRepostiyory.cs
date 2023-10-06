using Dapper;
using RealEstate_Dapper.Dtos.OurServicesDtos;
using RealEstate_Dapper.Dtos.PopulerLocationDtos;
using RealEstate_Dapper.Models.DapperContext;

namespace RealEstate_Dapper.Repositories.PopulerLocationRepositories
{
    public class PopulerLocationRepostiyory : IPopulerLocationRepository
    {
        private readonly Context _context;

        public PopulerLocationRepostiyory(Context context)
        {
            _context = context;
        }

        public async void CreatePopulerLocationAsync(CreatePopulerLocationDto createPopulerLocation)
        {
            string query = "INSERT INTO PopulerLocations (CityName, ImageUrl) VALUES (@cityName, @imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("cityName", createPopulerLocation.CityName);
            parameters.Add("imageUrl", createPopulerLocation.ImageUrl);

          



            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

       

        public async void DeletePopulerLocationAsync(int id)
        {
            string query = "Delete From PopulerLocations Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("locationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIDPopulerLocationDto> GetByIDPopulerLocation(int id)
        {
            string query = "SELECT * FROM PopulerLocations WHERE LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDPopulerLocationDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultPopulerLocationDto>> GetPopulerLocation()
        {

            string query = "SELECT * FROM PopulerLocations";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopulerLocationDto>(query);
                return values.ToList();
            }
        }

        public async void UpdatePopulerLocationAsync(UpdatePopulerLocationDto updatePopulerLocation)
        {

            var query = "UPDATE PopulerLocations SET CityName = @cityName,ImageUrl= @imageUrl WHERE LocationID= @locationID;";
            var parameters = new DynamicParameters();
            parameters.Add("cityName", updatePopulerLocation.CityName);
            parameters.Add("imageUrl", updatePopulerLocation.ImageUrl);
            parameters.Add("locationID", updatePopulerLocation.LocationID);





            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
