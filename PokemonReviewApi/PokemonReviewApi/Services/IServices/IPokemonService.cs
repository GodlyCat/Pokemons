using PokemonReviewApi.Entities;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface IPokemonService
    {
        PokemonEntity CreatePokemon(int ownerId, int categoryId, PokemonEntity createdPokemon);
        PokemonViewModel UpdatePokemon(int ownerId, int categoryId, PokemonViewModel updatedPokemon);
        void DeletePokemon(PokemonEntity deletedPokemon);
    }
}
