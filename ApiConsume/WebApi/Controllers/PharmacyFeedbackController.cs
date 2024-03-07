using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.FeedbackDto;
using DtoLayer.PharmacyDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyFeedbackController : Controller
    {
        private readonly IPharmacyFeedbackService _pharmacyFeedbackService;
        private readonly IPharmacyService _pharmacyService;
        private readonly IMapper _mapper;

        public PharmacyFeedbackController(IPharmacyFeedbackService pharmacyFeedbackService, IMapper mapper, IPharmacyService pharmacyService)
        {
            _pharmacyFeedbackService = pharmacyFeedbackService;
            _pharmacyService = pharmacyService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllFeedbacks()
        {
            var feedbackList = _pharmacyFeedbackService.TGetAll();
            return Ok(feedbackList);
        }

        [HttpGet("{pharmacyId}")]
        public IActionResult GetFeedbacksByPharmacyId([FromRoute(Name = "pharmacyId")] int pharmacyId)
        {
            var query = from feedback in _pharmacyFeedbackService.TGetAll()
                        join pharmacy in _pharmacyService.TGetAll() on feedback.PharmacyId equals pharmacy.PharmacyId
                        where pharmacy.PharmacyId == pharmacyId
                        select new PharmacyFeedbackResultDto
                        {
                            SenderMail = feedback.SenderMail,
                            Topic = feedback.Topic,
                            Content = feedback.Content,
                            Rating = feedback.Rating,
                            Date = feedback.Date,
                            Name = pharmacy.Name,
                            City = pharmacy.City,
                            District = pharmacy.District,
                            PharmacyId = pharmacy.PharmacyId
                        };

            return Ok(query.ToList());
        }

        [HttpPost]
        public IActionResult CreateOneFeedback([FromBody] CreatePharmacyFeedbackDto createFeedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var feedbackToCreate = _mapper.Map<PharmacyFeedback>(createFeedbackDto);

            var createdFeedback = _pharmacyFeedbackService.TInsert(feedbackToCreate);

            if (createdFeedback == null)
            {
                return BadRequest("Feedback creation failed.");
            }

            var createdFeedbackDto = _mapper.Map<CreatePharmacyFeedbackDto>(createdFeedback);
            return Ok(createdFeedbackDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneFeedbackById(int id)
        {
            var value = _pharmacyFeedbackService.TGetById(id);
            _pharmacyFeedbackService.TDelete(value);
            return NoContent();
        }
    }
}
