using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using FluentAssertions;
using PokemonBattle.BLL.Models;
using PokemonBattle.BLL.Services;
using PokemonBattle.DAL.Entities;
using PokemonBattle.DAL.Interfaces;
using PokemonBattle.BLL.Abstractions;
using PokemonBattle.BLL.Tests.TestData.Entities;
using PokemonBattle.BLL.Tests.TestData.Models;

namespace PokemonBattle.BLL.Tests.ServicesTests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryServiceTests()
        {
            _categoryRepository = new Mock<ICategoryRepository>();
            _mapper = new Mock<IMapper>();
            _categoryService = new CategoryService(_categoryRepository.Object, _mapper.Object);
        }

        [Fact]
        public void CategoryServiceGetCategories_ReturnsListOfCategories()
        {
            _categoryRepository.Setup(cat => cat.GetCategories())
            .Returns(CategoryEntityData.GetCategories());
            _mapper.Setup(m => m.Map<List<Category>>(It.IsAny<List<CategoryEntity>>()))
                .Returns(CategoryModelData.GetCategories());
            //Act
            var result = _categoryService.GetCategories();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Category>>();
        }
        [Fact]
        public void GetCategoryById_ValidId_ShouldReturnModel()
        {
            //Arrange
            _categoryRepository.Setup(catId => catId.GetCategoryById(CategoryEntityData.GetCategoryEntity.Id))
            .Returns(CategoryEntityData.GetCategoryEntity);
            _mapper.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
            .Returns(CategoryModelData.GetCategoryModel);
            //Act
            var result = _categoryService.GetCategoryById(CategoryEntityData.GetCategoryEntity.Id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.GetCategoryModel);
        }
        [Fact]
        public void GetCategoryById_InvalidId_ShouldReturnModel()
        {
            //Arrange
            _categoryRepository.Setup(catId => catId.GetCategoryById(CategoryEntityData.GetInvalidCategoryEntity.Id))
            .Returns(CategoryEntityData.GetInvalidCategoryEntity);
            _mapper.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
            .Returns(CategoryModelData.GetInvalidCategoryModel);
            //Act
            var result = _categoryService.GetCategoryById(CategoryEntityData.GetInvalidCategoryEntity.Id);
            //Assert
            result.Id.Should().Be(0);
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.GetInvalidCategoryModel);
        }
        [Fact]
        public async Task DeleteCategory_ValidId_ShouldReturnModel()
        {
            // Arrange
            _mapper.Setup(m => m.Map<CategoryEntity>(It.IsAny<Category>()))
                .Returns(CategoryEntityData.GetCategoryEntity);
            _categoryRepository.Setup(r => r.CreateCategory(CategoryEntityData.GetCategoryEntity))
                .Returns(CategoryEntityData.GetCategoryEntity);
            _mapper.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
                .Returns(CategoryModelData.GetCategoryModel);
            int Id = CategoryEntityData.GetCategoryEntity.Id;
            var categoryToDelete = CategoryEntityData.GetCategoryEntity;
            var categoryModelToDelete = CategoryModelData.GetCategoryModel;
            _categoryRepository.Setup(delId => delId.DeleteCategory(categoryToDelete));

            // Act
            var result = _categoryService.CreateCategory(categoryModelToDelete);
            _categoryService.DeleteCategory(CategoryEntityData.GetCategoryEntity.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.GetCategoryModel);
        }
        [Fact]
        public async Task CreateCategory_CategoryModel_ShouldReturnCValidModel()
        {
            // Arrange
            _mapper.Setup(m => m.Map<CategoryEntity>(It.IsAny<Category>()))
                .Returns(CategoryEntityData.GetCategoryEntity);
            _categoryRepository.Setup(r => r.CreateCategory(CategoryEntityData.GetCategoryEntity))
                .Returns(CategoryEntityData.GetCategoryEntity);
            _mapper.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
                .Returns(CategoryModelData.GetCategoryModel);

            // Act
            var result = _categoryService.CreateCategory(CategoryModelData.GetCategoryModel);

            // Assert
            _categoryRepository.Verify(r => r.CreateCategory(CategoryEntityData.GetCategoryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.GetCategoryModel);
        }
        [Fact]
        public async Task UpdateCategory_CategoryModel_ShouldReturnValidModel()
        {
            //Arrange
            _mapper.Setup(m => m.Map<CategoryEntity>(CategoryModelData.UpdateCategoryModel))
            .Returns(CategoryEntityData.UpdateCategoryEntity);
            _categoryRepository.Setup(r => r.UpdateCategory(CategoryEntityData.UpdateCategoryEntity))
           .Returns(CategoryEntityData.UpdateCategoryEntity);
            _mapper.Setup(m => m.Map<Category>(CategoryEntityData.UpdateCategoryEntity))
                .Returns(CategoryModelData.UpdateCategoryModel);
            //Act
            var result = _categoryService.UpdateCategory(CategoryModelData.UpdateCategoryModel.Id,CategoryModelData.UpdateCategoryModel);
            //Assert
            _categoryRepository.Verify(r => r.UpdateCategory(CategoryEntityData.UpdateCategoryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().NotBeEquivalentTo(CategoryModelData.GetCategoryModel);
        }
    }
}
