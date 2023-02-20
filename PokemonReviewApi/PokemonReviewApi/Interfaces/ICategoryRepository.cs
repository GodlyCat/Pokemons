using PokemonReviewApi.Entities;

namespace PokemonReviewApi.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryEntity> GetCategories();
        CategoryEntity? GetCategoryById(int id);
        bool CategoryExists(int Id); //for confirmation
        CategoryEntity CreateCategory(CategoryEntity createdCategory); //for create method, passing entire entity
        CategoryEntity UpdateCategory(CategoryEntity updatedCategory);
        void DeleteCategory(CategoryEntity deletedCategory);
    }
}