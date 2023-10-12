﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EmployeeDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44369/api/Employee");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createEmployeeDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44369/api/Employee", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync($"https://localhost:44369/api/Employee/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44369/api/Employee/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto model)
        {


            try
            {
                // model nesnesini kullanarak güncelleme işlemini gerçekleştirin
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                // Güncelleme isteği oluşturun ve API'ye gönderin
                var responseMessage = await client.PutAsync("https://localhost:44369/api/Employee", content);


                if (responseMessage.IsSuccessStatusCode)
                {
                    // Güncelleme başarılı olduysa başka bir sayfaya yönlendirin veya bir mesaj gösterin
                    return RedirectToAction("Index"); // Başarılı bir sayfaya yönlendirin
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Güncelleme başarısız oldu. Lütfen tekrar deneyin.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + ex.Message);
            }


            // ModelState geçerli değilse veya güncelleme başarısızsa formu tekrar gösterin
            return View(model);
        }
    }
}
