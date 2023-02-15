using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using System.Diagnostics.Metrics;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;

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
        public List<CountryViewModel> GetCountries()
        {
            var countries = _mapper.Map<List<CountryViewModel>>(_countryRepository.GetCountries()); 

            return countries;
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        [ProducesResponseType(400)]
        public CountryShortViewModel GetPokemon(int countryId) // should match with httpGet"{countryId}"
        {           
            var country = _mapper.Map<CountryShortViewModel>(_countryRepository.GetCountryById(countryId));        
            
            return country;
        }

        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CountryEntity))]
        public CountryShortViewModel GetCountryByOwner(int ownerId)
        {
            var country = _mapper.Map<CountryShortViewModel>(_countryRepository.GetCountryByOwnerId(ownerId));

            return country;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public CountryEntity CreateCountry([FromBody] CountryShortViewModel countryCreate)
        {

            var country = _countryRepository.GetCountries()
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper());

            var countryMap = _mapper.Map<CountryEntity>(countryCreate);
            _countryRepository.CreateCountry(countryMap);

            return country;
        }

        [HttpPut("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CountryViewModel UpdateCategory( [FromBody] CountryViewModel updatedCountry)
        {
            var countryMap = _mapper.Map<CountryEntity>(updatedCountry);
            _countryRepository.UpdateCountry(countryMap);
           
            return updatedCountry;
        }

        [HttpDelete("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CountryEntity DeleteCountry(int countryId)
        {
            var countryToDelete = _countryRepository.GetCountryById(countryId);
            _countryRepository.DeleteCountry(countryToDelete);
            
            return countryToDelete;
        }
        
    }
}
