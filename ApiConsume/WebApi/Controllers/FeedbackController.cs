using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.FeedbackDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllFeedbacks()
        {
            var feedbackList = _feedbackService.TGetAll();
            return Ok(feedbackList);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneFeedbackById([FromRoute(Name = "id")] int id)
        {
            var feedback = _feedbackService.TGetById(id);
            return Ok(feedback);
        }

        [HttpPost]
        public IActionResult CreateOneFeedback([FromBody] CreateFeedbackDto createFeedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var feedbackToCreate = _mapper.Map<Feedback>(createFeedbackDto);

            var createdFeedback = _feedbackService.TInsert(feedbackToCreate);

            if (createdFeedback == null)
            {
                return BadRequest("Feedback creation failed.");
            }

            var createdFeedbackDto = _mapper.Map<CreateFeedbackDto>(createdFeedback);
            return Ok(createdFeedbackDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneFeedbackById(int id)
        {
            var value = _feedbackService.TGetById(id);
            _feedbackService.TDelete(value);
            return NoContent();
        }
    }
}
