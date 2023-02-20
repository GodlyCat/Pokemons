using PokemonReviewApi.Entities;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface ICountryService
    {
        CountryShortViewModel CreateCountry(CountryShortViewModel createdCountry); //for create method, passing entire entity
        CountryShortViewModel UpdateCountry(int countryId, CountryShortViewModel updatedCountry);
        void DeleteCountry(int countryId);
    }
}
