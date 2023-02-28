using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using System.Diagnostics.Metrics;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Models;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Services.IServices;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryEntity>))]
        public List<CountryViewModel> GetCountries()
        {
            return _mapper.Map<List<CountryViewModel>>(_countryService.GetCountries());
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        [ProducesResponseType(400)]
        public CountryShortViewModel GetCountryById(int countryId) // should match with httpGet"{countryId}"
        {           
            return _mapper.Map<CountryShortViewModel>(_countryService.GetCountryById(countryId));
        }

        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        public CountryShortViewModel GetCountryByOwner(int ownerId)
        {
            return _mapper.Map<CountryShortViewModel>(_countryService.GetCountryByOwnerId(ownerId));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public CountryShortViewModel CreateCountry([FromBody] CountryShortViewModel countryCreate)
        {
            var countryMap = _mapper.Map<Country>(countryCreate);
            _countryService.CreateCountry(countryMap);
            return countryCreate;
        }

        [HttpPut("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CountryShortViewModel UpdateCountry([FromQuery] int countryId, [FromBody] CountryShortViewModel updatedCountry)
        {
            var countryMap = _mapper.Map<Country>(updatedCountry);
            _countryService.UpdateCountry(countryId, countryMap);
            return updatedCountry;
        }

        [HttpDelete("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public Country DeleteCountry(int countryId)
        {
            _countryService.DeleteCountry(countryId);
            return null;
        }
    }
}