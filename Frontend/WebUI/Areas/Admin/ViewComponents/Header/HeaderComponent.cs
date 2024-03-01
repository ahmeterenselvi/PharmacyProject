using DtoLayer.AnnouncementDto;
using DtoLayer.FeedbackDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.ViewComponents.Header
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HeaderComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var feedbackListTask = GetFeedbacksAsync();
            var announcementListTask = GetAnnouncementsAsync();

            await Task.WhenAll(feedbackListTask, announcementListTask);

            return View((await feedbackListTask, await announcementListTask));
        }

        private async Task<IEnumerable<FeedbackResultDto>> GetFeedbacksAsync()
        {
            using var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Feedback");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<FeedbackResultDto>>(jsonData);
            }
            return Enumerable.Empty<FeedbackResultDto>();
        }

        private async Task<IEnumerable<AnnouncementResultDto>> GetAnnouncementsAsync()
        {
            using var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Announcement");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<AnnouncementResultDto>>(jsonData);
            }
            return Enumerable.Empty<AnnouncementResultDto>();
        }
    }

}
