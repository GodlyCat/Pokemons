using PokemonReviewApi.Entities;
using System.Diagnostics.Metrics;

namespace PokemonReviewApi.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<CountryEntity> GetCountries();
        CountryEntity GetCountry(int id);
        CountryEntity GetCountryByOwner(int ownerId);
        ICollection<OwnerEntity> GetOwnersFromACountry(int countryId);
        bool CountryExists(int id);
        bool CreateCountry(CountryEntity country); //for create method, passing entire entity
        bool UpdateCountry(CountryEntity country);
        bool DeleteCountry(CountryEntity country);
        bool Save();
    }
}
