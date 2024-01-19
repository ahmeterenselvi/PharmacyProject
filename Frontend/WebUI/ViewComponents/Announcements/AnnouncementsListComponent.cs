using BusinessLayer.Abstract;
using DtoLayer.AnnouncementDto;
using DtoLayer.PharmacyDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.Announcements
{
    public class AnnouncementsListComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AnnouncementsListComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Announcement");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<AnnouncementResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
