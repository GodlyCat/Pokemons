using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int Id);
        bool CreateCategory(Category category); //for create method, passing entire entity
        bool Save();
    }
}
