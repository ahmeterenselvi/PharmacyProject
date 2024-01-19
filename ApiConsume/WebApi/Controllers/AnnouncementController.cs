using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.AnnouncementDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAnnouncements()
        {
            var announcementList = _announcementService.TGetAll();
            return Ok(announcementList);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneAnnouncementById([FromRoute(Name = "id")] int id)
        {
            var announcement = _announcementService.TGetById(id);
            return Ok(announcement);
        }

        [HttpPost]
        public IActionResult CreateOneAnnouncement([FromBody] CreateAnnouncementDto createAnnouncementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var announcementToCreate = _mapper.Map<Announcement>(createAnnouncementDto);

            var createdAnnouncement = _announcementService.TInsert(announcementToCreate);

            if (createdAnnouncement == null)
            {
                return BadRequest("Announcement creation failed.");
            }

            var createdAnnouncementDto = _mapper.Map<CreateAnnouncementDto>(createdAnnouncement);
            return Ok(createdAnnouncementDto);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOneAnnouncementById(int id, [FromBody] UpdateAnnouncementDto updateAnnouncementDto)
        {
            var existingAnnouncement = _announcementService.TGetById(id);

            if (existingAnnouncement == null)
            {
                return NotFound("Announcement not found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var announcementToUpdate = _mapper.Map<Announcement>(updateAnnouncementDto);
            announcementToUpdate.AnnouncementId = id;

            _announcementService.TUpdate(announcementToUpdate);

            return Ok("Announcement updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneAnnouncementById(int id)
        {
            var value = _announcementService.TGetById(id);
            _announcementService.TDelete(value);
            return NoContent();
        }
    }
}
