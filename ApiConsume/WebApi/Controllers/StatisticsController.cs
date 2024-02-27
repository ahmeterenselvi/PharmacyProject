using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public StatisticsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetTotalCount()
        {
            var totalCounts = new Dictionary<string, int>
            {
                { "Pharmacy", _serviceManager.PharmacyService.TCount() },
                { "Announcement", _serviceManager.AnnouncementService.TCount() },
                { "Feedback", _serviceManager.FeedbackService.TCount() },
                { "Subscribe", _serviceManager.SubscribeService.TCount() },
                { "DailyQuote", _serviceManager.DailyQuoteService.TCount() },
                { "DrugTip", _serviceManager.DrugTipService.TCount() }
            };

            return Ok(totalCounts);
        }
    }
}
