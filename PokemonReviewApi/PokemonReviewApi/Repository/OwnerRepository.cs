/*
using PokemonBattleApi.Data;
using PokemonBattleApi.Entities;
using PokemonBattleApi.Interfaces;

namespace PokemonBattleApi.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }
        public OwnerEntity CreateOwner(OwnerEntity createdOwner)
        {
            _context.Add(createdOwner);
            _context.SaveChanges();
            return createdOwner;
        }

        public void DeleteOwner(OwnerEntity deletedOwner)
        {
            _context.Remove(deletedOwner);
            _context.SaveChanges();
        }

        public OwnerEntity? GetOwnerById(int ownerId)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == ownerId);
        }

        public IEnumerable<OwnerEntity> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public IEnumerable<OwnerEntity> GetOwnersByCountryId(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }

        public IEnumerable<OwnerEntity> GetOwnersByPokeId(int pokeId)
        {
            return _context.PokemonOwners.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Owner).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(ow => ow.Id == ownerId);
        }

        public OwnerEntity UpdateOwner(OwnerEntity updatedOwner)
        {
            _context.Update(updatedOwner);
            _context.SaveChanges();
            return updatedOwner;
        }
    }
}
*/