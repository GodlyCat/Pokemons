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
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryEntity>))]
        public List<CountryViewModel> GetCountries()
        {
            return _countryService.GetCountries();
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        [ProducesResponseType(400)]
        public CountryShortViewModel GetCountryById(int countryId) // should match with httpGet"{countryId}"
        {           
            return _countryService.GetCountryById(countryId);
        }

        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        public CountryShortViewModel GetCountryByOwner(int ownerId)
        {
            return _countryService.GetCountryByOwnerId(ownerId);
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