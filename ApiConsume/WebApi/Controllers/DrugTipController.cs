using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DrugTipDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugTipController : ControllerBase
    {
        private readonly IDrugTipService _drugTipService;
        private readonly IMapper _mapper;

        public DrugTipController(IDrugTipService drugTipService, IMapper mapper)
        {
            _drugTipService = drugTipService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDrugTips()
        {
            var drugTipList = _drugTipService.TGetAll();
            return Ok(drugTipList);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneDrugTipById([FromRoute(Name = "id")] int id)
        {
            var drugTip = _drugTipService.TGetById(id);
            return Ok(drugTip);
        }

        [HttpPost]
        public IActionResult CreateOneDrugTip([FromBody] CreateDrugTipDto createDrugTipDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var drugTipToCreate = _mapper.Map<DrugTip>(createDrugTipDto);

            var createdDrugTip = _drugTipService.TInsert(drugTipToCreate);

            if (createdDrugTip == null)
            {
                return BadRequest("DrugTip creation failed.");
            }

            var createdDrugTipDto = _mapper.Map<CreateDrugTipDto>(createdDrugTip);
            return Ok(createdDrugTipDto);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOneDrugTipById(int id, [FromBody] UpdateDrugTipDto updateDrugTipDto)
        {
            var existingDrugTip = _drugTipService.TGetById(id);

            if (existingDrugTip == null)
            {
                return NotFound("DrugTip not found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var drugTipToUpdate = _mapper.Map<DrugTip>(updateDrugTipDto);
            drugTipToUpdate.DrugTipId = id;

            _drugTipService.TUpdate(drugTipToUpdate);

            return Ok("DrugTip updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneDrugTipById(int id)
        {
            var value = _drugTipService.TGetById(id);
            _drugTipService.TDelete(value);
            return NoContent();
        }
    }
}
