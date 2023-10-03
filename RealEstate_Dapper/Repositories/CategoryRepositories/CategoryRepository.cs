using RealEstate_Dapper.Dtos.CategoryDtos;
using RealEstate_Dapper.Models.DapperContext;
using Dapper;
namespace RealEstate_Dapper.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "INSERT INTO Category (CategoryName,CategoryStatus) VALUES (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("categoryName", createCategoryDto.CategoryName);
            parameters.Add("categoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategoryAsync(int id)
        {
            string query="Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query="SELECT * FROM Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
            }

        public async Task<GetByIdDto> GetCategory(int id)
        {
            string query="SELECT * FROM Category WHERE CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDto>(query,parameters);
                return values;
            }

        }

        public async void UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var query= "UPDATE Category SET CategoryName = @categoryName,CategoryStatus = @categoryStatus WHERE CategoryID = @categoryID;";
            var parameters = new DynamicParameters();
            parameters.Add("categoryName", updateCategoryDto.CategoryName);
            parameters.Add("categoryStatus", true);
            parameters.Add("categoryID", updateCategoryDto.CategoryID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
    }

