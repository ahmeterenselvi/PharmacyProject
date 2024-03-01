using DtoLayer.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Subscribe");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<SubscribeResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7208/api/Subscribe/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.PostAsync($"https://localhost:7208/api/Subscribe/SendMail",null);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7208/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsync("api/Subscribe/SendMail", null);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }
    }
}
