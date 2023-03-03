using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using PokemonBattleApi.Interfaces;
using PokemonBattleApi.Services.IServices;
using PokemonBattleApi.ViewModels;
using PokemonBattleApi.Entities;
using PokemonBattleApi.Models;

namespace PokemonBattleApi.Controllers
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
        public CountryViewModel GetCountryById(int countryId) // should match with httpGet"{countryId}"
        {
            return _mapper.Map<CountryViewModel>(_countryService.GetCountryById(countryId));
        }

        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        public CountryViewModel GetCountryByOwner(int ownerId)
        {
            return _mapper.Map<CountryViewModel>(_countryService.GetCountryByOwnerId(ownerId));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public CountryViewModel CreateCountry([FromBody] CountryShortViewModel countryCreate)
        {
            var countryMap = _mapper.Map<Country>(countryCreate);
            var countryViewModelMap = _countryService.CreateCountry(countryMap);
            return _mapper.Map<CountryViewModel>(countryViewModelMap);
        }

        [HttpPut("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CountryViewModel UpdateCountry([FromQuery] int countryId, [FromBody] CountryShortViewModel updatedCountry)
        {
            var countryMap = _mapper.Map<Country>(updatedCountry);
            var countryViewModelMap = _countryService.UpdateCountry(countryId, countryMap);
            return _mapper.Map<CountryViewModel>(countryViewModelMap);
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