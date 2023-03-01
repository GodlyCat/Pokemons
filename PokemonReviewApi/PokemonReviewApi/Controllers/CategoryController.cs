using AutoMapper;
using PokemonReviewApi.Helper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Services.IServices;
using PokemonReviewApi.Models;
using System.Collections.Generic;
namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper) 
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryEntity>))]
        public List<CategoryViewModel> GetCategories()
        {
            return _mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories());
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(CategoryEntity))]
        [ProducesResponseType(400)]
        public CategoryViewModel GetCategory(int categoryId)
        {
            return _mapper.Map<CategoryViewModel>(_categoryService.GetCategoryById(categoryId));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public CategoryViewModel CreateCategory([FromBody] CategoryShortViewModel categoryCreate)
        {
            var categoryMap= _mapper.Map<Category>(categoryCreate);
            _categoryService.CreateCategory(categoryMap);
            return _mapper.Map<CategoryViewModel>(categoryMap);
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CategoryViewModel UpdateCategory([FromQuery] int categoryId, [FromBody] CategoryShortViewModel updatedCategory)
        {
            var categoryMap = _mapper.Map<Category>(updatedCategory);
            _categoryService.UpdateCategory(categoryId, categoryMap);
            return _mapper.Map<CategoryViewModel>(categoryMap);
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public CategoryViewModel DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return null;
        }
    }
}