namespace PokemonReviewApi.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemonCategoryEntity> PokemonCategories { get; set; }
    }
}
