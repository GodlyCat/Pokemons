using PokemonReviewApi.Entities;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface IOwnerService
    {
        List<OwnerViewModel> GetOwners(); //ICollection is intemediate between IEnumerable and a IList (IEnumerable is more bare-boned version)
        OwnerShortViewModel? GetOwnerById(int ownerId);
        List<OwnerShortViewModel> GetOwnersByPokeId(int pokeId);
        List<OwnerShortViewModel> GetOwnersByCountryId(int countryId);
        OwnerShortViewModel CreateOwner(int countryId, OwnerShortViewModel createdOwner);
        OwnerShortViewModel UpdateOwner(int countryId, int ownerId, OwnerShortViewModel updatedOwner);
        void DeleteOwner(int ownerId);
    }
}
