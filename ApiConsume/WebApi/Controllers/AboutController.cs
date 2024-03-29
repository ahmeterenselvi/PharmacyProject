﻿using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAbout()
        {
            var about= _aboutService.TGetAbout();
            return Ok(about);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOneAboutById(int id, [FromBody] UpdateAboutDto updateAboutDto)
        {
            var existingAbout = _aboutService.TGetById(id);

            if (existingAbout == null)
            {
                return NotFound("About not found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aboutToUpdate = _mapper.Map<About>(updateAboutDto);
            aboutToUpdate.AboutId = id;

            _aboutService.TUpdate(aboutToUpdate);

            return Ok("About updated successfully");
        }
    }
}
