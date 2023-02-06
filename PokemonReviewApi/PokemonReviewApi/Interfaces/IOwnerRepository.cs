using PokemonReviewApi.Entities;
namespace PokemonReviewApi.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<OwnerEntity> GetOwners(); //ICollection is intemediate between IEnumerable and a IList (IEnumerable is more bare-boned version)
        OwnerEntity GetOwner(int ownerId);
        ICollection<OwnerEntity> GetOwnerOfAPokemon(int pokeId);
        ICollection<PokemonEntity> GetPokemonByOwner(int ownerId);
        bool OwnerExists(int ownerId);
        bool UpdateOwner(OwnerEntity owner);
        bool CreateOwner(OwnerEntity owner); //for create method, passing entire entity
        bool DeleteOwner(OwnerEntity owner);
        bool Save();
    }
}