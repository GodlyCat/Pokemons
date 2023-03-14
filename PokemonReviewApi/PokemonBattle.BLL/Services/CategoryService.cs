namespace PokemonBattle.BLL.Services
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

        public Category CreateCategory(Category createdCategory)
        {
            var category = _categoryRepository.GetCategories()
           .FirstOrDefault(c => c.Name.Trim().ToUpper() == createdCategory.Name.TrimEnd().ToUpper());

            var categoryMap = _mapper.Map<CategoryEntity>(createdCategory);
            var categoryModelMap = _categoryRepository.CreateCategory(categoryMap);
            return _mapper.Map<Category>(categoryModelMap);
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryToDelete = _categoryRepository.GetCategoryById(categoryId);
            _categoryRepository.DeleteCategory(categoryToDelete);
        }

        public List<Category> GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            return _mapper.Map<List<Category>>(categories);
        }

        public Category? GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return _mapper.Map<Category>(category);
        }

        public Category UpdateCategory(int categoryId, Category updatedCategory)
        {
            var categoryMap = _mapper.Map<CategoryEntity>(updatedCategory);
            categoryMap.Id = categoryId;
            var categoryModelMap = _categoryRepository.UpdateCategory(categoryMap);

            return _mapper.Map<Category>(categoryModelMap);
        }
    }
}
