using PokemonReviewApi.Entities;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface IPokemonService
    {
        PokemonEntity CreatePokemon(int ownerId, int categoryId, PokemonEntity createdPokemon);
        PokemonShortViewModel UpdatePokemon(int pokeId, int ownerId, int categoryId, PokemonShortViewModel updatedPokemon);
        void DeletePokemon(PokemonEntity deletedPokemon);
    }
}
