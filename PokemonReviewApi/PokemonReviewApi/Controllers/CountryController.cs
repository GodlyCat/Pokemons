using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Entities;
using System.Diagnostics.Metrics;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryEntity>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryViewModel>>(_countryRepository.GetCountries()); 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int countryId) // should match with httpGet"{countryId}"
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();                      

            var country = _mapper.Map<CountryViewModel>(_countryRepository.GetCountryById(countryId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);        
            
            return Ok(country);
        }

        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var country = _mapper.Map<CountryViewModel>(_countryRepository.GetCountryByOwnerId(ownerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryShortViewModel countryCreate)
        {
            if (countryCreate == null)
                return BadRequest(ModelState);

            var country = _countryRepository.GetCountries()
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper());

            if (country != null)
            {
                ModelState.AddModelError("", "Country already Exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryMap = _mapper.Map<CountryEntity>(countryCreate);
            _countryRepository.CreateCountry(countryMap);

            return Ok("Successfully created");
        }

        [HttpPut("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int countryId, [FromBody] CountryViewModel updatedCountry)
        {
            if (updatedCountry == null)
                return BadRequest(ModelState);

            if (countryId != updatedCountry.Id)
                return BadRequest(ModelState);

            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryMap = _mapper.Map<CountryEntity>(updatedCountry);
            _countryRepository.UpdateCountry(countryMap);
           
            return NoContent();
        }

        [HttpDelete("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
            {
                return NotFound();
            }
            var countryToDelete = _countryRepository.GetCountryById(countryId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _countryRepository.DeleteCountry(countryToDelete);
            
            return NoContent();
        }
        
    }
}
