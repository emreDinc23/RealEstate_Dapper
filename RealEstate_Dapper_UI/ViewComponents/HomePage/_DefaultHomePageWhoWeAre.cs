using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageWhoWeAre : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44369/api/WhoWeAreDetail");
            var responseMessage2 = await client2.GetAsync("https://localhost:44369/api/WhoWeAreServices");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();


                var value =JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDtos>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultWhoWeAreServiceDtos>>(jsonData2);
                ViewBag.Title = value.Select(x=>x.Title).FirstOrDefault();
                ViewBag.Subtitle = value.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.Description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.Description2 = value.Select(x => x.Description2).FirstOrDefault();


                return View(value2);
            }
            return View();
        }

    
        public _DefaultHomePageWhoWeAre(IHttpClientFactory httpClientFactory)
        {
            
            _httpClientFactory = httpClientFactory;
        }
    }
    
}
