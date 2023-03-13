using AutoMapper;
using PokemonBattle.BLL.Abstractions;
using PokemonBattle.DAL.Entities;
using PokemonBattle.BLL.Models;
using PokemonBattle.DAL.Interfaces;

namespace PokemonBattle.BLL.Services
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

        public Country CreateCountry(Country createdCountry)
        {
            var country = _countryRepository.GetCountries()
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == createdCountry.Name.TrimEnd().ToUpper());

            var countryMap = _mapper.Map<CountryEntity>(createdCountry);
            var countryModelMap = _countryRepository.CreateCountry(countryMap);

            return _mapper.Map<Country>(countryModelMap);
        }

        public void DeleteCountry(int countryId)
        {
            var countryToDelete = _countryRepository.GetCountryById(countryId);
            _countryRepository.DeleteCountry(countryToDelete);
        }

        public List<Country> GetCountries()
        {
            var countries = _countryRepository.GetCountries();

            return _mapper.Map<List<Country>>(countries);
        }

        public Country? GetCountryById(int id)
        {
            var country = _countryRepository.GetCountryById(id);

            return _mapper.Map<Country>(country);
        }

        public Country? GetCountryByOwnerId(int ownerId)
        {
            var country = _countryRepository.GetCountryByOwnerId(ownerId);

            return _mapper.Map<Country>(country);
        }

        public Country UpdateCountry(int countryId, Country updatedCountry)
        {
            var countryMap = _mapper.Map<CountryEntity>(updatedCountry);
            countryMap.Id = countryId;
            var countryModelMap = _countryRepository.UpdateCountry(countryMap);

            return _mapper.Map<Country>(countryModelMap);
        }
    }
}