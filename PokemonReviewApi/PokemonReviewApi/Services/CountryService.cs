using AutoMapper;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Services.IServices;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public CountryShortViewModel CreateCountry(CountryShortViewModel createdCountry)
        {
            var country = _countryRepository.GetCountries()
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == createdCountry.Name.TrimEnd().ToUpper());

            var countryMap = _mapper.Map<CountryEntity>(createdCountry);
            _countryRepository.CreateCountry(countryMap);

            return createdCountry;
        }

        public void DeleteCountry(int countryId)
        {
            var countryToDelete = _countryRepository.GetCountryById(countryId);
            _countryRepository.DeleteCountry(countryToDelete);
        }

        public CountryShortViewModel UpdateCountry(int countryId, CountryShortViewModel updatedCountry)
        {
            var countryMap = _mapper.Map<CountryEntity>(updatedCountry);
            countryMap.Id = countryId;
            _countryRepository.UpdateCountry(countryMap);

            return updatedCountry;
        }
    }
}