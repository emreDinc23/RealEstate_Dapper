using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly  IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                // API'ye istekler yaparak verileri çekme
                var activeCategoryCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/ActiveCategoryCount");
                var activeEmployeeCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/ActiveEmployeeCount");
                var apartmentCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/ApartmenCount");
                var averageProductPriceByRentResponse = await client.GetAsync("https://localhost:44369/api/Statistics/AvarageProductPriceByRent");
                var averageProductPriceBySaleResponse = await client.GetAsync("https://localhost:44369/api/Statistics/AvarageProductPriceBySale");
                var averageRoomCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/AvarageRoomCount");
                var categoryCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/CategoryCount");
                var categoryByMaxProductCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/CategoryNameByMaxProductCount");
                var cityNameByMaxProductCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/CityNameByMaxProductCount");
                var differentCityCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/DifferentCityCount");
                var employeeNameByMaxProductCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/EmployeeNameByMaxProductCount");
                var lastProductPriceResponse = await client.GetAsync("https://localhost:44369/api/Statistics/LastProductPrice");
                var newestBuildingYearResponse = await client.GetAsync("https://localhost:44369/api/Statistics/NewestBuildingYear");
                var oldestBuildingYearResponse = await client.GetAsync("https://localhost:44369/api/Statistics/OldestBuildingYear");
                var passiveCategoryCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/PasiveCategoryCount");
                var productCountResponse = await client.GetAsync("https://localhost:44369/api/Statistics/ProductCount");
                // Diğer istekler de aynı şekilde yapılır

                // İsteklerin başarılı olup olmadığını kontrol etme
                if (activeCategoryCountResponse.IsSuccessStatusCode && activeEmployeeCountResponse.IsSuccessStatusCode &&
    apartmentCountResponse.IsSuccessStatusCode && averageProductPriceByRentResponse.IsSuccessStatusCode &&
    averageProductPriceBySaleResponse.IsSuccessStatusCode && averageRoomCountResponse.IsSuccessStatusCode &&
    categoryCountResponse.IsSuccessStatusCode && categoryByMaxProductCountResponse.IsSuccessStatusCode &&
    cityNameByMaxProductCountResponse.IsSuccessStatusCode && differentCityCountResponse.IsSuccessStatusCode &&
    employeeNameByMaxProductCountResponse.IsSuccessStatusCode && lastProductPriceResponse.IsSuccessStatusCode &&
    newestBuildingYearResponse.IsSuccessStatusCode && oldestBuildingYearResponse.IsSuccessStatusCode &&
    passiveCategoryCountResponse.IsSuccessStatusCode && productCountResponse.IsSuccessStatusCode)
                {
                    // Verileri çekme ve modele dönüştürme
                    var activeCategoryCount = JsonConvert.DeserializeObject<int>(await activeCategoryCountResponse.Content.ReadAsStringAsync());
                    var activeEmployeeCount = JsonConvert.DeserializeObject<int>(await activeEmployeeCountResponse.Content.ReadAsStringAsync());
                    var apartmentCount = JsonConvert.DeserializeObject<int>(await apartmentCountResponse.Content.ReadAsStringAsync());
                    var averageProductPriceByRent = JsonConvert.DeserializeObject<decimal>(await averageProductPriceByRentResponse.Content.ReadAsStringAsync());
                    var averageProductPriceBySale = JsonConvert.DeserializeObject<decimal>(await averageProductPriceBySaleResponse.Content.ReadAsStringAsync());
                    var averageRoomCount = JsonConvert.DeserializeObject<int>(await averageRoomCountResponse.Content.ReadAsStringAsync());
                    var categoryCount = JsonConvert.DeserializeObject<int>(await categoryCountResponse.Content.ReadAsStringAsync());
                    var categoryByMaxProductCount = await categoryByMaxProductCountResponse.Content.ReadAsStringAsync();
                    var cityNameByMaxProductCount = await cityNameByMaxProductCountResponse.Content.ReadAsStringAsync();
                    var differentCityCount = JsonConvert.DeserializeObject<int>(await differentCityCountResponse.Content.ReadAsStringAsync());
                    var employeeNameByMaxProductCount = await employeeNameByMaxProductCountResponse.Content.ReadAsStringAsync();
                    var lastProductPrice = JsonConvert.DeserializeObject<decimal>(await lastProductPriceResponse.Content.ReadAsStringAsync());
                    var newestBuildingYear = await newestBuildingYearResponse.Content.ReadAsStringAsync();
                    var oldestBuildingYear = await oldestBuildingYearResponse.Content.ReadAsStringAsync();
                    var passiveCategoryCount = JsonConvert.DeserializeObject<int>(await passiveCategoryCountResponse.Content.ReadAsStringAsync());
                    var productCount = JsonConvert.DeserializeObject<int>(await productCountResponse.Content.ReadAsStringAsync());
                    // Diğer veriler de aynı şekilde dönüştürülür

                    // Alınan verileri ViewData ile View'a aktarın
                    ViewData["ActiveCategoryCount"] = activeCategoryCount;
                    ViewData["ActiveEmployeeCount"] = activeEmployeeCount;
                    ViewData["ApartmentCount"] = apartmentCount;
                    ViewData["AverageProductPriceByRent"] = averageProductPriceByRent;
                    ViewData["AverageProductPriceBySale"] = averageProductPriceBySale;
                    ViewData["AverageRoomCount"] = averageRoomCount;
                    ViewData["CategoryCount"] = categoryCount;
                    ViewData["CategoryNameByMaxProductCount"] = categoryByMaxProductCount;
                    ViewData["CityNameByMaxProductCount"] = cityNameByMaxProductCount;
                    ViewData["DifferentCityCount"] = differentCityCount;
                    ViewData["EmployeeNameByMaxProductCount"] = employeeNameByMaxProductCount;
                    ViewData["LastProductPrice"] = lastProductPrice;
                    ViewData["NewestBuildingYear"] = newestBuildingYear;
                    ViewData["OldestBuildingYear"] = oldestBuildingYear;
                    ViewData["PassiveCategoryCount"] = passiveCategoryCount;
                    ViewData["ProductCount"] = productCount;
                    // Diğer verileri de ViewData ile aktarın
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API isteği başarısız oldu.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + ex.Message);
            }

            return View();
        }
    }
      
    }

