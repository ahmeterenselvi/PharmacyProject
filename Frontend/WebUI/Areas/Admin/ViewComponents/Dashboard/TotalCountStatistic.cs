using DtoLayer.PharmacyDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class TotalCountStatistic : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TotalCountStatistic(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pharmacies = await GetTopCitiesWithMostPharmacies();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Statistics");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonData);
                return View((values, pharmacies));
            }
            return View();
        }

        public async Task<List<CityPharmacyCountDto>> GetTopCitiesWithMostPharmacies()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Pharmacy/GetTopCitiesWithMostPharmacies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CityPharmacyCountDto>>(jsonData);
                return values;
            }
            return new List<CityPharmacyCountDto>();
        }
    }
}
