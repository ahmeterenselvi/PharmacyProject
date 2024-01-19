using DtoLayer.DailyQuote;
using DtoLayer.DrugTipDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.DailyQuote
{
    public class DailyQuoteComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DailyQuoteComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/DailyQuote");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<DailyQuoteResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
