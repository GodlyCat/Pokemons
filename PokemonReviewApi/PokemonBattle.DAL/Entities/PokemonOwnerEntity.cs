namespace PokemonBattle.DAL.Entities
{
    public class PokemonOwnerEntity //join table
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public PokemonEntity Pokemon { get; set; }
        public OwnerEntity Owner { get; set; }
    }
}
