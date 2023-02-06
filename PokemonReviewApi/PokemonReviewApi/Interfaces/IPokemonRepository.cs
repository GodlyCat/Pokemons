using PokemonReviewApi.Entities;
namespace PokemonReviewApi.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<PokemonEntity> GetPokemons();
        PokemonEntity GetPokemon(int id); // for detail endpoints 
        PokemonEntity GetPokemon(string name); 
        int GetPokemonHealth(int pokeId);
        int GetPokemonDamage(int pokeId);
        bool PokemonExists(int pokeId);
        bool CreatePokemon(int ownerId, int categoryId, PokemonEntity pokemon);
        bool UpdatePokemon(int ownerId, int categoryId, PokemonEntity pokemon);
        bool DeletePokemon(PokemonEntity pokemon);
        bool Save();
    }
}