using PokemonReviewApi.Entities;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface IPokemonService
    {
        List<PokemonViewModel> GetPokemons();
        List<PokemonEntity> GetPokemonsByCategoryId(int categoryId);
        List<PokemonShortViewModel> GetPokemonsByOwnerId(int ownerId);
        PokemonShortViewModel? GetPokemonById(int id);
        PokemonShortViewModel? GetPokemonByName(string name);
        int GetPokemonHealth(int pokeId);
        int GetPokemonDamage(int pokeId);
        PokemonShortViewModel CreatePokemon(int ownerId, int categoryId, PokemonShortViewModel createdPokemon);
        PokemonShortViewModel UpdatePokemon(int pokeId, int ownerId, int categoryId, PokemonShortViewModel updatedPokemon);
        void DeletePokemon(int pokeId);
    }
}