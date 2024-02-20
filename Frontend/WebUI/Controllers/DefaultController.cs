using DtoLayer.FeedbackDto;
using DtoLayer.PharmacyDto;
using DtoLayer.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index() => View();

        public PartialViewResult _HeadPartial() => PartialView();

        public PartialViewResult _TopHeaderPartial() => PartialView();

        public PartialViewResult _NavbarPartial() => PartialView();

        [HttpGet]
        public PartialViewResult _PharmaciesOnDutyListPartial()=> PartialView();

        [HttpPost]
        public IActionResult _PharmaciesOnDutyListPartial(CitiesandDistrictsResultDto citiesandDistrictsResultDto)
        {
            if (string.IsNullOrEmpty(citiesandDistrictsResultDto.City) || string.IsNullOrEmpty(citiesandDistrictsResultDto.District))
            {
                ModelState.AddModelError("", "Şehir ve ilçe bilgileri geçerli değil.");
                return View();
            }

            TempData["City"] = citiesandDistrictsResultDto.City;
            TempData["District"] = citiesandDistrictsResultDto.District;

            return RedirectToAction("Index","Pharmacy");
        }

        [HttpGet]
        public PartialViewResult _FeedbackPartial() => PartialView();

        [HttpPost]
        public async Task<IActionResult> _FeedbackPartial(CreateFeedbackDto createFeedbackDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeedbackDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7208/api/Feedback", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public PartialViewResult _SubscribePartial() => PartialView();

        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7208/api/Subscribe", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult _FooterPartial() => PartialView();

        public PartialViewResult _ScriptsPartial() => PartialView();
    }
}
