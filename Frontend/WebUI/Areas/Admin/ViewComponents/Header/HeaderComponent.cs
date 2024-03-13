using DtoLayer.AnnouncementDto;
using DtoLayer.FeedbackDto;
using DtoLayer.Profile;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.ViewComponents.Header
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public HeaderComponent(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var feedbackListTask = GetFeedbacksAsync();
            var announcementListTask = GetAnnouncementsAsync();
            var userImage = GetUserImageUrlAsync();

            await Task.WhenAll(feedbackListTask, announcementListTask, userImage);

            return View((await feedbackListTask, await announcementListTask, await userImage));
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

        private async Task<string> GetUserImageUrlAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return user?.ImageUrl ?? "";
        }

    }

}
