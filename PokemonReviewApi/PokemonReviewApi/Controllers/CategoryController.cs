using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Repository;
using PokemonReviewApi.Services.IServices;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, ICategoryService categoryService, IMapper mapper) 
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryEntity>))]
        public List<CategoryViewModel> GetCategories()
        {
            var categories = _categoryRepository.GetCategories(); //without automapper - var categories = _categoryRepository.GetCategory()

            return _mapper.Map<List<CategoryViewModel>>(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(CategoryEntity))]
        [ProducesResponseType(400)]
        public CategoryShortViewModel GetCategory(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);

            return _mapper.Map<CategoryShortViewModel>(category);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public CategoryShortViewModel CreateCategory([FromBody] CategoryShortViewModel categoryCreate)
        {
            _categoryService.CreateCategory(categoryCreate);
            return categoryCreate;
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CategoryShortViewModel UpdateCategory([FromQuery] int categoryId, [FromBody] CategoryShortViewModel updatedCategory)
        {
            _categoryService.UpdateCategory(categoryId, updatedCategory);
            return updatedCategory;
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CategoryEntity DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return null;
        }
    }
}