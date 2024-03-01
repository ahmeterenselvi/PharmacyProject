using DtoLayer.AboutDto;
using DtoLayer.AnnouncementDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.About
{
    public class AboutComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AboutResultDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
