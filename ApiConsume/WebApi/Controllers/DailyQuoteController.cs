using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DailyQuote;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyQuoteController : ControllerBase
    {
        private readonly IDailyQuoteService _dailyQuoteService;
        private readonly IMapper _mapper;

        public DailyQuoteController(IDailyQuoteService dailyQuoteService, IMapper mapper)
        {
            _dailyQuoteService = dailyQuoteService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDailyQuotes()
        {
            var dailyQuoteList = _dailyQuoteService.TGetAll();
            return Ok(dailyQuoteList);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneDailyQuoteById([FromRoute(Name = "id")] int id)
        {
            var dailyQuote = _dailyQuoteService.TGetById(id);
            return Ok(dailyQuote);
        }

        [HttpPost]
        public IActionResult CreateOneDailyQuote([FromBody] CreateDailyQuoteDto createDailyQuoteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var dailyQuoteToCreate = _mapper.Map<DailyQuote>(createDailyQuoteDto);

            var createdDailyQuote = _dailyQuoteService.TInsert(dailyQuoteToCreate);

            if (createdDailyQuote == null)
            {
                return BadRequest("DailyQuote creation failed.");
            }

            var createdDailyQuoteDto = _mapper.Map<CreateDailyQuoteDto>(createdDailyQuote);
            return Ok(createdDailyQuoteDto);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOneDailyQuoteById(int id, [FromBody] UpdateDailyQuoteDto updateDailyQuoteDto)
        {
            var existingDailyQuote = _dailyQuoteService.TGetById(id);

            if (existingDailyQuote == null)
            {
                return NotFound("DailyQuote not found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dailyQuoteToUpdate = _mapper.Map<DailyQuote>(updateDailyQuoteDto);
            dailyQuoteToUpdate.DailyQuoteId = id;

            _dailyQuoteService.TUpdate(dailyQuoteToUpdate);

            return Ok("DailyQuote updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneDailyQuoteById(int id)
        {
            var value = _dailyQuoteService.TGetById(id);
            _dailyQuoteService.TDelete(value);
            return NoContent();
        }
    }
}
