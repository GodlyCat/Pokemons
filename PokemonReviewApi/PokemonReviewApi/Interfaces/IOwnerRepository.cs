using PokemonReviewApi.Entities;
namespace PokemonReviewApi.Interfaces
{
    public interface IOwnerRepository
    {
        IEnumerable<OwnerEntity> GetOwners(); //ICollection is intemediate between IEnumerable and a IList (IEnumerable is more bare-boned version)
        OwnerEntity? GetOwnerById(int ownerId);
        IEnumerable<OwnerEntity> GetOwnersByPokeId(int pokeId);
        IEnumerable<OwnerEntity> GetOwnersByCountryId(int countryId);  //moved this from ICountryRepo
        bool OwnerExists(int ownerId);
        OwnerEntity UpdateOwner(OwnerEntity updatedOwner);
        OwnerEntity CreateOwner(OwnerEntity createdOwner); //for create method, passing entire entity
        void DeleteOwner(OwnerEntity deletedOwner);
    }
}