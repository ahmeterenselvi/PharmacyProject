using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SubscribeDto;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Security.Policy;
using WebApi.Models.Mail;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public SubscribeController(ISubscribeService subscribeService, IMapper mapper, IAnnouncementService announcementService)
        {
            _subscribeService = subscribeService;
            _announcementService = announcementService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSubscribes()
        {
            var subscribeList = _subscribeService.TGetAll();
            return Ok(subscribeList);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneSubscribeById([FromRoute(Name = "id")] int id)
        {
            var subscribe = _subscribeService.TGetById(id);
            return Ok(subscribe);
        }

        [HttpPost]
        public IActionResult CreateOneSubscribe([FromBody] CreateSubscribeDto createSubscribeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var subscribeToCreate = _mapper.Map<Subscribe>(createSubscribeDto);

            var createdSubscribe = _subscribeService.TInsert(subscribeToCreate);

            if (createdSubscribe == null)
            {
                return BadRequest("Subscribe creation failed.");
            }

            var createdSubscribeDto = _mapper.Map<CreateSubscribeDto>(createdSubscribe);
            return Ok(createdSubscribeDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneSubscribeById(int id)
        {
            var value = _subscribeService.TGetById(id);
            _subscribeService.TDelete(value);
            return NoContent();
        }

        [HttpPost("SendMail")]
        public IActionResult SendMail()
        {
            var subscribeList = _subscribeService.TGetAll();
            var lastAnnouncement = _announcementService.TGetAll()
                .OrderByDescending(x => x.AnnouncementId)
                .FirstOrDefault();

            if (lastAnnouncement == null)
            {
                // Handle the case where there is no announcement available
                return NotFound("Duyuru bulunamadı.");
            }

            using (SmtpClient client = new SmtpClient())
            {
                foreach (var subscribe in subscribeList)
                {
                    MimeMessage mimeMessage = new MimeMessage();

                    mimeMessage.From.Add(new MailboxAddress("Eczanematik", "eczanematik78@gmail.com"));
                    mimeMessage.To.Add(new MailboxAddress(subscribe.Mail, subscribe.Mail));
                    mimeMessage.Subject = lastAnnouncement.Title;

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = lastAnnouncement.Description;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    try
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("eczanematik78@gmail.com", "vfon iwpy yjcp tqzl");
                        client.Send(mimeMessage);
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions occurred during sending email
                        Console.WriteLine($"{subscribe.Mail} adresine e-posta gönderilemedi: {ex.Message}");
                        // You might want to log the error or take appropriate action
                    }
                    finally
                    {
                        if (client.IsConnected)
                        {
                            client.Disconnect(true);
                        }
                    }
                }
                return Ok("E-postalar başarıyla gönderildi.");
            }
        }
    }
}
