using DtoLayer.PharmacyDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.Pharmacies
{
    public class PharmaciesOnDutyListComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PharmaciesOnDutyListComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(CitiesandDistrictsResultDto resultDto)
        {
            await GetCitiesandDistricts();

            return View(resultDto);
        }

        public async Task GetCitiesandDistricts()
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var responseMessage = await client.GetAsync("https://localhost:7208/api/Pharmacy/GetCitiesandDistricts");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<CitiesandDistrictsResultDto>>(jsonData);

                    var cities = values.Select(c => c.City).Distinct().ToList();
                    var districtsByCity = values.GroupBy(c => c.City).ToDictionary(g => g.Key, g => g.Select(x => x.District).ToList());

                    ViewBag.Cities = cities;
                    ViewBag.DistrictsByCity = districtsByCity;
                }
                else
                {
                    ModelState.AddModelError("", "Bir hata oluştu.");
                }
            }
        }
    }
}
