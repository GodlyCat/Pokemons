using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Entities;

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
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryViewModel>>(_categoryRepository.GetCategories()); //without automapper - var categories = _categoryRepository.GetCategory()
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(CategoryEntity))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();                     

            var category = _mapper.Map<CategoryViewModel>(_categoryRepository.GetCategoryById(categoryId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);          //same spec return type

            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryShortViewModel categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            var category = _categoryRepository.GetCategories()
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd().ToUpper());
            if (category != null)
            {
                ModelState.AddModelError("", "Category already Exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<CategoryEntity>(categoryCreate);
            _categoryRepository.CreateCategory(categoryMap);
            return Ok("Successfully created");
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryViewModel updatedCategory)
        {
            if (updatedCategory == null)
                return BadRequest(ModelState);

            if (categoryId != updatedCategory.Id)
                return BadRequest(ModelState);

            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<CategoryEntity>(updatedCategory);
            _categoryRepository.UpdateCategory(categoryMap);
           
            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
            {
                return NotFound();
            }
            var categoryToDelete = _categoryRepository.GetCategoryById(categoryId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _categoryRepository.DeleteCategory(categoryToDelete);
            return NoContent();
        }
    }
}