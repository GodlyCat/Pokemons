using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
    public interface IOwnerRepository
    {                                   //If you need more functionality - accepting ICollection is good; IEnumerable is finite (iterates and yields integers in a while true loop)
        ICollection<Owner> GetOwners(); //ICollection is intemediate between IEnumerable(IEnumerable is more bare-boned version) and a IList
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExists(int ownerId);
    }
}
