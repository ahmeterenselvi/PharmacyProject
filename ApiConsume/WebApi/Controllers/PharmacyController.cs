using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.PharmacyDto;
using EntityLayer.Concrete;
using EntityLayer.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;
        private readonly IMapper _mapper;

        public PharmacyController(IPharmacyService pharmacyService, IMapper mapper)
        {
            _pharmacyService = pharmacyService;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetAllPharmacys()
        {
            var pharmacyList = _pharmacyService.TGetAllPharmaciesQueryable();
            return Ok(pharmacyList);
        }

        [HttpGet("GetPaginatedPharmacies")]
        public IActionResult GetPaginatedPharmacies([FromQuery] PharmacyParameters pharmacyParameters)
        {
            var pagedResult = _pharmacyService.TGetPaginatedPharmacies(pharmacyParameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.pharmacies);
        }

        [HttpGet("top10highrated")]
        public IActionResult GetTop10HighRatedPharmacies()
        {
            var top10Pharmacies = _pharmacyService.TGetAll()
                .OrderByDescending(p => p.Rate)
                .Take(10)
                .ToList();

            return Ok(top10Pharmacies);
        }

        [HttpGet("{id}")]
        public IActionResult GetOnePharmacyById([FromRoute(Name = "id")] int id)
        {
            var pharmacy = _pharmacyService.TGetById(id);
            return Ok(pharmacy);
        }

        [HttpGet("OnDuty")]
        public IActionResult GetPharmaciesByCityAndDistrict([FromQuery] string city, [FromQuery] string district)
        {
            if (string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(district))
            {
                return BadRequest("Geçersiz şehir veya ilçe.");
            }

            var pharmacies = _pharmacyService.TGetAll();

            //Dal'a GetByCityAndDistrictOnDuty(city, district) at
            var matchingPharmacies = pharmacies
                .Where(p => string.Equals(p.City, city, StringComparison.OrdinalIgnoreCase) &&
                            string.Equals(p.District, district, StringComparison.OrdinalIgnoreCase) &&
                            p.IsOnDuty)
                .ToList();

            if (!matchingPharmacies.Any())
            {
                return NotFound("Nöbetçi eczane bulunamadı.");
            }

            return Ok(matchingPharmacies);
        }

        [HttpGet("GetTopCitiesWithMostPharmacies")]
        public IActionResult GetTopCitiesWithMostPharmacies()
        {
            var pharmacies=_pharmacyService.TGetGetTopCitiesWithMostPharmacies();
            return Ok(pharmacies);
        }

        [HttpGet("GetCitiesandDistricts")]
        public IActionResult GetCitiesandDistricts()
        {
            var pharmacies = _pharmacyService.TGetAll();

            var groupedCitiesAndDistricts = pharmacies.GroupBy(p => new { p.City, p.District });

            var result = groupedCitiesAndDistricts.Select(g => new CitiesandDistrictsResultDto
            {
                City = g.Key.City,
                District = g.Key.District
            });

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOnePharmacy([FromBody] CreatePharmacyDto createPharmacyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pharmacyToCreate = _mapper.Map<Pharmacy>(createPharmacyDto);

            var createdPharmacy = _pharmacyService.TInsert(pharmacyToCreate);

            if (createdPharmacy == null)
            {
                return BadRequest("Pharmacy creation failed.");
            }

            var createdPharmacyDto = _mapper.Map<CreatePharmacyDto>(createdPharmacy);
            return Ok(createdPharmacyDto);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOnePharmacyById(int id, [FromBody] UpdatePharmacyDto updatePharmacyDto)
        {
            var existingPharmacy = _pharmacyService.TGetById(id);

            if (existingPharmacy == null)
            {
                return NotFound("Pharmacy not found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pharmacyToUpdate = _mapper.Map<Pharmacy>(updatePharmacyDto);
            pharmacyToUpdate.PharmacyId = id; // Güncellenen eczanenin kimliğini atama

            _pharmacyService.TUpdate(pharmacyToUpdate);

            return Ok("Pharmacy updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOnePharmacyById(int id)
        {
            var value = _pharmacyService.TGetById(id);
            _pharmacyService.TDelete(value);
            return NoContent();
        }
    }
}
