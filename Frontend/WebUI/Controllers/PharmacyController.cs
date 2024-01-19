using DtoLayer.PharmacyDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class PharmacyController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public PharmacyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var city = TempData["City"];
            var district = TempData["District"];
            var responseMessage = await client.GetAsync($"https://localhost:7208/api/Pharmacy/OnDuty?city={city}&district={district}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<PharmacyResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
