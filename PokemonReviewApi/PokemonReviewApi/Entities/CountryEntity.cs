namespace PokemonReviewApi.Models
{
    public class CountryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OwnerEntity> Owners { get; set; } //one to many
    }
}
