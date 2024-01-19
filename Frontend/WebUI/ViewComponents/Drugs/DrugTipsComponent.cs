using DtoLayer.AboutDto;
using DtoLayer.DrugTipDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.Drugs
{
    public class DrugTipsComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DrugTipsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/DrugTip");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<DrugTipResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
