using PokemonBattleApi.Models;

namespace PokemonBattleApi.Services.IServices
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category? GetCategoryById(int id);
        Category CreateCategory(Category createdCategory);
        Category UpdateCategory(int categoryId, Category updatedCategory);
        void DeleteCategory(int categoryId);
    }
}
