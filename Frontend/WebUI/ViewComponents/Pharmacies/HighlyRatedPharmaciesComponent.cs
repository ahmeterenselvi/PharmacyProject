using DtoLayer.AboutDto;
using DtoLayer.PharmacyDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.Pharmacies
{
    public class HighlyRatedPharmaciesComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HighlyRatedPharmaciesComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Pharmacy/top10highrated");
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
