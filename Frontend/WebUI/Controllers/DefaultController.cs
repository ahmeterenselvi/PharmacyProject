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

        public PartialViewResult HeadPartial() => PartialView();

        public PartialViewResult TopHeaderPartial() => PartialView();

        public PartialViewResult NavbarPartial() => PartialView();

        [HttpGet]
        public PartialViewResult PharmaciesOnDutyListPartial()=> PartialView();

        [HttpPost]
        public IActionResult PharmaciesOnDutyListPartial(CitiesandDistrictsResultDto citiesandDistrictsResultDto)
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
        public PartialViewResult FeedbackPartial() => PartialView();

        [HttpPost]
        public async Task<IActionResult> FeedbackPartial(CreateFeedbackDto createFeedbackDto)
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
        public PartialViewResult SubscribePartial() => PartialView();

        [HttpPost]
        public async Task<IActionResult> SubscribePartial(CreateSubscribeDto createSubscribeDto)
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

        public PartialViewResult FooterPartial() => PartialView();

        public PartialViewResult ScriptsPartial() => PartialView();
    }
}
