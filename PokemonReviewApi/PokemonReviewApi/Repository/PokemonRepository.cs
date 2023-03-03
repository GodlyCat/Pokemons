using PokemonBattleApi.Data;
using PokemonBattleApi.Entities;
using PokemonBattleApi.Interfaces;

namespace PokemonBattleApi.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }
        public PokemonEntity CreatePokemon(int ownerId, int categoryId, PokemonEntity createdPokemon)
        {
            var pokemonOwnerEntity = _context.Owners.FirstOrDefault(a => a.Id == ownerId);
            var category = _context.Categories.FirstOrDefault(a => a.Id == categoryId);
            var pokemonOwner = new PokemonOwnerEntity
            {
                Owner = pokemonOwnerEntity,
                Pokemon = createdPokemon,
            };
            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategoryEntity()
            {
                Category = category,
                Pokemon = createdPokemon,
            };
            _context.Add(pokemonCategory);
            _context.Add(createdPokemon);
            _context.SaveChanges();
            return createdPokemon;
        }

        public void DeletePokemon(PokemonEntity deletedPokemon)
        {
            _context.Remove(deletedPokemon);
            _context.SaveChanges();
        }

        public PokemonEntity? GetPokemonById(int id)
        {
            return _context.Pokemon.FirstOrDefault(p => p.Id == id);
        }

        public PokemonEntity? GetPokemonByName(string name)
        {
            return _context.Pokemon.FirstOrDefault(p => p.Name == name);
        }

        public int GetPokemonDamage(int pokeId)
        {
            return _context.Pokemon.FirstOrDefault(p => p.Id == pokeId).Damage;
        }

        public int GetPokemonHealth(int pokeId)
        {
            return _context.Pokemon.FirstOrDefault(p => p.Id == pokeId).Health;
        }

        public IEnumerable<PokemonEntity> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public IEnumerable<PokemonEntity> GetPokemonsByCategoryId(int categoryId)
        {
            return _context.PokemonCategories.Where(ca => ca.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public IEnumerable<PokemonEntity> GetPokemonsByOwnerId(int ownerId)
        {
            return _context.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(p => p.Pokemon).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }

        public PokemonEntity UpdatePokemon(int ownerId, int categoryId, PokemonEntity updatedPokemon)
        {
            _context.Update(updatedPokemon);
            _context.SaveChanges();
            return updatedPokemon;
        }
    }
}
