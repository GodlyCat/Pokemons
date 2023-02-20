using PokemonReviewApi.Entities;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface IPokemonService
    {
        PokemonShortViewModel CreatePokemon(int ownerId, int categoryId, PokemonShortViewModel createdPokemon);
        PokemonShortViewModel UpdatePokemon(int pokeId, int ownerId, int categoryId, PokemonShortViewModel updatedPokemon);
        void DeletePokemon(int pokeId);
    }
}