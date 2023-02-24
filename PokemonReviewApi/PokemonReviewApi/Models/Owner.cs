using PokemonReviewApi.Entities;

namespace PokemonReviewApi.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; } //one to many
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
    }
}
