using PokemonReviewApi.Entities;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface IOwnerService
    {
        OwnerShortViewModel CreateOwner(int countryId, OwnerShortViewModel createdOwner);
        OwnerShortViewModel UpdateOwner(int countryId, int ownerId, OwnerShortViewModel updatedOwner);
        void DeleteOwner(int ownerId);
    }
}
