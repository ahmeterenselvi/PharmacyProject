using DtoLayer.FeedbackDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminFeedbackController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminFeedbackController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Feedback");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<FeedbackResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7208/api/Feedback/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FeedbackDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7208/api/Feedback/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<FeedbackResultDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
