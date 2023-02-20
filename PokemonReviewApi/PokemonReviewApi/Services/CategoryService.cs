using AutoMapper;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Services.IServices;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryShortViewModel CreateCategory(CategoryShortViewModel createdCategory)
        {
            var category = _categoryRepository.GetCategories()
           .FirstOrDefault(c => c.Name.Trim().ToUpper() == createdCategory.Name.TrimEnd().ToUpper());

            var categoryMap = _mapper.Map<CategoryEntity>(createdCategory);
            _categoryRepository.CreateCategory(categoryMap);
            return createdCategory;
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryToDelete = _categoryRepository.GetCategoryById(categoryId);
            _categoryRepository.DeleteCategory(categoryToDelete);
        }

        public CategoryShortViewModel UpdateCategory(int categoryId, CategoryShortViewModel updatedCategory)
        {
            var categoryMap = _mapper.Map<CategoryEntity>(updatedCategory);
            categoryMap.Id = categoryId;
            _categoryRepository.UpdateCategory(categoryMap);

            return updatedCategory;
        }
    }
}
