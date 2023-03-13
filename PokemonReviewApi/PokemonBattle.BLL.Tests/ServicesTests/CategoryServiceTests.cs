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
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ICategoryService _categoryService;
        public CategoryServiceTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _mapperMock = new Mock<IMapper>();
            _categoryService = new CategoryService(_categoryRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void CategoryServiceGetCategories_ReturnsListOfCategories()
        {
            _categoryRepositoryMock.Setup(cat => cat.GetCategories())
            .Returns(CategoryEntityData.GetCategories());
            _mapperMock.Setup(m => m.Map<List<Category>>(It.IsAny<List<CategoryEntity>>()))
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
            _categoryRepositoryMock.Setup(catId => catId.GetCategoryById(CategoryEntityData.GetCategoryEntity.Id))
            .Returns(CategoryEntityData.GetCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
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
            _categoryRepositoryMock.Setup(catId => catId.GetCategoryById(CategoryEntityData.GetInvalidCategoryEntity.Id))
            .Returns(CategoryEntityData.GetInvalidCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
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
            _mapperMock.Setup(m => m.Map<CategoryEntity>(It.IsAny<Category>()))
                .Returns(CategoryEntityData.GetCategoryEntity);
            _categoryRepositoryMock.Setup(r => r.CreateCategory(CategoryEntityData.GetCategoryEntity))
                .Returns(CategoryEntityData.GetCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
                .Returns(CategoryModelData.GetCategoryModel);
            int Id = CategoryEntityData.GetCategoryEntity.Id;
            var categoryToDelete = CategoryEntityData.GetCategoryEntity;
            var categoryModelToDelete = CategoryModelData.GetCategoryModel;
            _categoryRepositoryMock.Setup(delId => delId.DeleteCategory(categoryToDelete));

            // Act
            var result = _categoryService.CreateCategory(categoryModelToDelete);
            _categoryService.DeleteCategory(CategoryEntityData.GetCategoryEntity.Id);

            // Assert
            _categoryRepositoryMock.Verify(r => r.DeleteCategory(It.IsAny<CategoryEntity>()));
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.GetCategoryModel);
        }

        [Fact]
        public async Task CreateCategory_ValidCategoryModel_ShouldReturnCValidModel()
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<CategoryEntity>(It.IsAny<Category>()))
                .Returns(CategoryEntityData.GetCategoryEntity);
            _categoryRepositoryMock.Setup(r => r.CreateCategory(CategoryEntityData.GetCategoryEntity))
                .Returns(CategoryEntityData.GetCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
                .Returns(CategoryModelData.GetCategoryModel);

            // Act
            var result = _categoryService.CreateCategory(CategoryModelData.GetCategoryModel);

            // Assert
            _categoryRepositoryMock.Verify(r => r.CreateCategory(CategoryEntityData.GetCategoryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.GetCategoryModel);
        }

        [Fact]
        public async Task UpdateCategory_ValidCategoryModel_ShouldReturnValidModel()
        {
            //Arrange
            _mapperMock.Setup(m => m.Map<CategoryEntity>(CategoryModelData.UpdateCategoryModel))
            .Returns(CategoryEntityData.UpdateCategoryEntity);
            _categoryRepositoryMock.Setup(r => r.UpdateCategory(CategoryEntityData.UpdateCategoryEntity))
           .Returns(CategoryEntityData.UpdateCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(CategoryEntityData.UpdateCategoryEntity))
                .Returns(CategoryModelData.UpdateCategoryModel);
            //Act
            var result = _categoryService.UpdateCategory(CategoryModelData.UpdateCategoryModel.Id,CategoryModelData.UpdateCategoryModel);
            //Assert
            _categoryRepositoryMock.Verify(r => r.UpdateCategory(CategoryEntityData.UpdateCategoryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().NotBeEquivalentTo(CategoryModelData.GetCategoryModel);
        }
    }
}
