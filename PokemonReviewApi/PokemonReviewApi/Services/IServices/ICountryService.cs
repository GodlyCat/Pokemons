using PokemonReviewApi.Entities;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface ICountryService
    {
        List<CountryViewModel> GetCountries();
        CountryShortViewModel? GetCountryById(int id);
        CountryShortViewModel? GetCountryByOwnerId(int ownerId);
        CountryShortViewModel CreateCountry(CountryShortViewModel createdCountry); //for create method, passing entire entity
        CountryShortViewModel UpdateCountry(int countryId, CountryShortViewModel updatedCountry);
        void DeleteCountry(int countryId);
    }
}
