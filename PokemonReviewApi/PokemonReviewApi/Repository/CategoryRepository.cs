using PokemonReviewApi.Data;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;

namespace PokemonReviewApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int Id)
        {
            return _context.Categories.Any(c => c.Id == Id);
        }

        public CategoryEntity CreateCategory(CategoryEntity createdCategory)
        {
            _context.Add(createdCategory);
            _context.SaveChanges();
            return createdCategory;
        }

        public void DeleteCategory(CategoryEntity deletedCategory)
        {
            _context.Remove(deletedCategory);
            _context.SaveChanges();
        }

        public IEnumerable<CategoryEntity> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public CategoryEntity? GetCategoryById(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public CategoryEntity UpdateCategory(CategoryEntity updatedCategory)
        {
            _context.Update(updatedCategory);
            _context.SaveChanges();
            return updatedCategory;
        }
    }
}
