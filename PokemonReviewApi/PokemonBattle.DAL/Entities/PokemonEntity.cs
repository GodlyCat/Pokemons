
namespace PokemonBattle.DAL.Entities
{
    public class PokemonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public ICollection<PokemonOwnerEntity> PokemonOwners { get; set; }
        public ICollection<PokemonCategoryEntity> PokemonCategories { get; set; }
    }
}
