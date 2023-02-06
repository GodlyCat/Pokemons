namespace PokemonReviewApi.Entities
{
    public class OwnerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }
        public int CountryId { get; set; }
        public CountryEntity Country { get; set; } //one to many
        public ICollection<PokemonOwnerEntity> PokemonOwners { get; set; }
    }
}
