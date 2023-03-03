using System.Diagnostics;

namespace PokemonBattleApi.Entities
{
    public class PokemonCategoryEntity //join table
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public PokemonEntity Pokemon { get; set; }
        public CategoryEntity Category { get; set; }

    }
}
