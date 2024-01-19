using DtoLayer.PharmacyDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebUI.ViewComponents.Pharmacies
{
    public class PharmaciesOnDutyListComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PharmaciesOnDutyListComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Pharmacy/GetCitiesandDistricts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<CitiesandDistrictsResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
