using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class SubscribeChart:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscribeChart(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Statistics");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
