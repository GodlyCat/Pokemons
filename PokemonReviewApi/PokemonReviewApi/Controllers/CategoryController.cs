using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Repository;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryEntity>))]
        public List<CategoryViewModel> GetCategories()
        {
            var categories = _mapper.Map<List<CategoryViewModel>>(_categoryRepository.GetCategories()); //without automapper - var categories = _categoryRepository.GetCategory()

            return categories;
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(CategoryEntity))]
        [ProducesResponseType(400)]
        public CategoryShortViewModel GetCategory(int categoryId)
        {
            var category = _mapper.Map<CategoryShortViewModel>(_categoryRepository.GetCategoryById(categoryId));


            return category;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public CategoryEntity CreateCategory([FromBody] CategoryShortViewModel categoryCreate)
        {
            var category = _categoryRepository.GetCategories()
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd().ToUpper());

            var categoryMap = _mapper.Map<CategoryEntity>(categoryCreate);
            _categoryRepository.CreateCategory(categoryMap);
            return category;
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CategoryViewModel UpdateCategory( [FromBody] CategoryViewModel updatedCategory)
        {
            var categoryMap = _mapper.Map<CategoryEntity>(updatedCategory);
            _categoryRepository.UpdateCategory(categoryMap);
           
            return updatedCategory;
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CategoryEntity DeleteCategory(int categoryId)
        {
            var categoryToDelete = _categoryRepository.GetCategoryById(categoryId);
            _categoryRepository.DeleteCategory(categoryToDelete);
            return categoryToDelete;
        }
    }
}