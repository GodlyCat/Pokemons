using PokemonBattleApi.Entities;

namespace PokemonBattleApi.Interfaces
{
    public interface IPokemonRepository
    {
        IEnumerable<PokemonEntity> GetPokemons();
        IEnumerable<PokemonEntity> GetPokemonsByCategoryId(int categoryId); //moved this from ICategoryRepo
        IEnumerable<PokemonEntity> GetPokemonsByOwnerId(int ownerId);       //moved this fromIOwnerRepo
        PokemonEntity? GetPokemonById(int id); // for detail endpoints 
        PokemonEntity? GetPokemonByName(string name);
        int GetPokemonHealth(int pokeId);
        int GetPokemonDamage(int pokeId);
        bool PokemonExists(int pokeId);
        PokemonEntity CreatePokemon(int ownerId, int categoryId, PokemonEntity createdPokemon);
        PokemonEntity UpdatePokemon(int ownerId, int categoryId, PokemonEntity updatedPokemon);
        void DeletePokemon(PokemonEntity deletedPokemon);
    }
}