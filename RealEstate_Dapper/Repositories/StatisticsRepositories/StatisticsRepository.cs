using Dapper;
using RealEstate_Dapper.Dtos.CategoryDtos;
using RealEstate_Dapper.Models.DapperContext;

namespace RealEstate_Dapper.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public  int ActiveCategoryCount()
        {
            string query = "Select count(*) from Category where CategoryStatus=1";
            using (var connection =_context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {

            string query = "Select count(*) from Employee where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmenCount()
        {
            string query = "Select count(*) from Product where ProductCategory=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AvarageProductPriceByRent()
        {
            string query = "SELECT Avg(ProductPrice) FROM Product WHERE Type= 'Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AvarageProductPriceBySale()
        {
            string query = "SELECT Avg(ProductPrice) FROM Product WHERE Type= 'Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int AvarageRoomCount()
        {
            string query = "SELECT Avg(RoomCount) FROM ProductDetail ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "SELECT Count(*) FROM Category ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "SELECT TOP 1 c.CategoryName FROM Product AS p INNER JOIN Category AS c ON p.ProductCategory = c.CategoryID GROUP BY c.CategoryName ORDER BY COUNT(p.ProductCategory) DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "SELECT TOP 1 ProductCity FROM Product GROUP BY ProductCity ORDER BY COUNT(*) DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }
        
        public int DifferentCityCount()
        {
            string query = "SELECT COUNT(DISTINCT ProductCity) AS TotalCities FROM Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
        //SELECT TOP 1 e.Name FROM Product AS p INNER JOIN Employee AS e ON p.EmployeeID = e.EmployeeID GROUP BY e.Name ORDER BY COUNT(p.ProductID) DESC;
        public string EmployeeNameByMaxProductCount()
        {
            string query = "SELECT TOP 1 e.Name FROM Product AS p INNER JOIN Employee AS e ON p.EmployeeID = e.EmployeeID GROUP BY e.Name ORDER BY COUNT(p.ProductID) DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }
        //
        public decimal LastProductPrice()
        {
            string query = "SELECT TOP 1 ProductPrice FROM Product ORDER BY ProductID DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }
        //
        public string NewestBuildingYear()
        {
            string query = "SELECT MAX(BuildYear) AS NewestBuildingYear FROM ProductDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }
        //;
        public string OldestBuildingYear()
        {
            string query = "SELECT MIN(BuildYear) AS OldestBuildingYear FROM ProductDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }
        
        public int PasiveCategoryCount()
        {
            string query = "SELECT COUNT(*) AS PassiveCategoryCount FROM Category WHERE CategoryStatus = 0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
            
        }
        //
        public int ProductCount()
        {
            string query = "SELECT COUNT(*) AS ProductCount FROM Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
