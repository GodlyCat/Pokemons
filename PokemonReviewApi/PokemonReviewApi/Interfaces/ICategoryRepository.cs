using PokemonReviewApi.Entities;
namespace PokemonReviewApi.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<CategoryEntity> GetCategories();
        CategoryEntity GetCategory(int id);
        ICollection<PokemonEntity> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int Id); //for confirmation
        bool CreateCategory(CategoryEntity category); //for create method, passing entire entity
        bool UpdateCategory(CategoryEntity category);
        bool DeleteCategory(CategoryEntity category);
        bool Save();
    }
}