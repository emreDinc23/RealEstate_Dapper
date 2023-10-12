namespace RealEstate_Dapper.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PasiveCategoryCount();
        int ProductCount();
        int ApartmenCount();
        string EmployeeNameByMaxProductCount();
        string CategoryNameByMaxProductCount();
        decimal AvarageProductPriceByRent();
        decimal AvarageProductPriceBySale();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int AvarageRoomCount();
        int ActiveEmployeeCount();

        

    }
}
