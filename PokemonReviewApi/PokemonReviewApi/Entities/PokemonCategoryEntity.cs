using System.Diagnostics;

namespace PokemonReviewApi.Models
{
    public class PokemonCategoryEntity //join table
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public PokemonEntity Pokemon { get; set; }
        public CategoryEntity Category { get; set; }

    }
}
