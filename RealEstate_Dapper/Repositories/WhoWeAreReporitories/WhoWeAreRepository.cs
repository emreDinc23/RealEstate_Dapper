using Dapper;
using RealEstate_Dapper.Dtos.CategoryDtos;
using RealEstate_Dapper.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper.Models.DapperContext;

namespace RealEstate_Dapper.Repositories.WhoWeAreReporitories
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "INSERT INTO WhoWeAreDetail (Title,Subtitle,Description1,Description2) VALUES (@title,@subTitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createWhoWeAreDetailDto.Title);
            parameters.Add("@subTitle", createWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2);          
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetailDto(int id)
        {

            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "SELECT * FROM WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDto> GetByIDWhoWeAreDetail(int id)
        {
            string query = "SELECT * FROM WhoWeAreDetail WHERE WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, parameters);
                return values;
            }
        }

       

        public async void UpdateWhoWeAreDetailDto(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            var query = "UPDATE WhoWeAreDetail SET Title = @title,Subtitle = @subtitle,Description1=@description1,Description2=@description2 WHERE WhoWeAreDetailID = @whoWeAreDetailID;";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", updateWhoWeAreDetailDto.WhoWeAreDetailID);

            parameters.Add("@title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle",updateWhoWeAreDetailDto.Subtitle );
            parameters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", updateWhoWeAreDetailDto.Description2);
           



            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
