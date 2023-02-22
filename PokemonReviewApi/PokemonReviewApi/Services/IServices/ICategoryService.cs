using PokemonReviewApi.Entities;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetCategories();
        CategoryShortViewModel? GetCategoryById(int id);
        CategoryShortViewModel CreateCategory(CategoryShortViewModel createdCategory);
        CategoryShortViewModel UpdateCategory(int categoryId, CategoryShortViewModel updatedCategory);
        void DeleteCategory(int categoryId);
    }
}
