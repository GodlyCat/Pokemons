using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using System.Diagnostics.Metrics;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Services.IServices;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, ICountryService countryService, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _countryService = countryService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryEntity>))]
        public List<CountryViewModel> GetCountries()
        {
            var countries = _countryRepository.GetCountries(); 

            return _mapper.Map<List<CountryViewModel>>(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        [ProducesResponseType(400)]
        public CountryShortViewModel GetPokemon(int countryId) // should match with httpGet"{countryId}"
        {           
            var country = _countryRepository.GetCountryById(countryId);        
            
            return _mapper.Map<CountryShortViewModel>(country);
        }

        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        public CountryShortViewModel GetCountryByOwner(int ownerId)
        {
            var country = _countryRepository.GetCountryByOwnerId(ownerId);

            return _mapper.Map<CountryShortViewModel>(country);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public CountryShortViewModel CreateCountry([FromBody] CountryShortViewModel countryCreate)
        {
            _countryService.CreateCountry(countryCreate);
            return countryCreate;
        }

        [HttpPut("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CountryShortViewModel UpdateCountry([FromQuery] int countryId, [FromBody] CountryShortViewModel updatedCountry)
        {
            _countryService.UpdateCountry(countryId, updatedCountry);
            return updatedCountry;
        }

        [HttpDelete("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CountryEntity DeleteCountry(int countryId)
        {
            _countryService.DeleteCountry(countryId);
            return null;
        }
    }
}
