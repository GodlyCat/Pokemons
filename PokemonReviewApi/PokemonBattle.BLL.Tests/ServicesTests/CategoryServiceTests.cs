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
            .Returns(CategoryEntityData.ValidCategories());
            _mapperMock.Setup(m => m.Map<List<Category>>(It.IsAny<List<CategoryEntity>>()))
                .Returns(CategoryModelData.ValidCategories());
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
            _categoryRepositoryMock.Setup(catId => catId.GetCategoryById(CategoryEntityData.ValidCategoryEntity.Id))
            .Returns(CategoryEntityData.ValidCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
            .Returns(CategoryModelData.ValidCategoryModel);
            //Act
            var result = _categoryService.GetCategoryById(CategoryEntityData.ValidCategoryEntity.Id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.ValidCategoryModel);
        }

        [Fact]
        public void GetCategoryById_InvalidId_ShouldReturnModel()
        {
            //Arrange
            _categoryRepositoryMock.Setup(catId => catId.GetCategoryById(CategoryEntityData.InvalidCategoryEntity.Id))
            .Returns(CategoryEntityData.InvalidCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
            .Returns(CategoryModelData.InvalidCategoryModel);
            //Act
            var result = _categoryService.GetCategoryById(CategoryEntityData.InvalidCategoryEntity.Id);
            //Assert
            result.Id.Should().Be(0);
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.InvalidCategoryModel);
        }

        [Fact]
        public async Task DeleteCategory_ValidId_ShouldReturnModel()
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<CategoryEntity>(It.IsAny<Category>()))
                .Returns(CategoryEntityData.ValidCategoryEntity);
            _categoryRepositoryMock.Setup(r => r.CreateCategory(CategoryEntityData.ValidCategoryEntity))
                .Returns(CategoryEntityData.ValidCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
                .Returns(CategoryModelData.ValidCategoryModel);
            int Id = CategoryEntityData.ValidCategoryEntity.Id;
            var categoryToDelete = CategoryEntityData.ValidCategoryEntity;
            var categoryModelToDelete = CategoryModelData.ValidCategoryModel;
            _categoryRepositoryMock.Setup(delId => delId.DeleteCategory(categoryToDelete));

            // Act
            var result = _categoryService.CreateCategory(categoryModelToDelete);
            _categoryService.DeleteCategory(CategoryEntityData.ValidCategoryEntity.Id);

            // Assert
            _categoryRepositoryMock.Verify(r => r.DeleteCategory(It.IsAny<CategoryEntity>()));
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.ValidCategoryModel);
        }

        [Fact]
        public async Task CreateCategory_ValidCategoryModel_ShouldReturnCValidModel()
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<CategoryEntity>(It.IsAny<Category>()))
                .Returns(CategoryEntityData.ValidCategoryEntity);
            _categoryRepositoryMock.Setup(r => r.CreateCategory(CategoryEntityData.ValidCategoryEntity))
                .Returns(CategoryEntityData.ValidCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(It.IsAny<CategoryEntity>()))
                .Returns(CategoryModelData.ValidCategoryModel);

            // Act
            var result = _categoryService.CreateCategory(CategoryModelData.ValidCategoryModel);

            // Assert
            _categoryRepositoryMock.Verify(r => r.CreateCategory(CategoryEntityData.ValidCategoryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().BeEquivalentTo(CategoryModelData.ValidCategoryModel);
        }

        [Fact]
        public async Task UpdateCategory_ValidCategoryModel_ShouldReturnValidModel()
        {
            //Arrange
            _mapperMock.Setup(m => m.Map<CategoryEntity>(CategoryModelData.ValidUpdateCategoryModel))
            .Returns(CategoryEntityData.ValidUpdateCategoryEntity);
            _categoryRepositoryMock.Setup(r => r.UpdateCategory(CategoryEntityData.ValidUpdateCategoryEntity))
           .Returns(CategoryEntityData.ValidUpdateCategoryEntity);
            _mapperMock.Setup(m => m.Map<Category>(CategoryEntityData.ValidUpdateCategoryEntity))
                .Returns(CategoryModelData.ValidUpdateCategoryModel);
            //Act
            var result = _categoryService.UpdateCategory(CategoryModelData.ValidUpdateCategoryModel.Id,CategoryModelData.ValidUpdateCategoryModel);
            //Assert
            _categoryRepositoryMock.Verify(r => r.UpdateCategory(CategoryEntityData.ValidUpdateCategoryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Category>();
            result.Should().NotBeEquivalentTo(CategoryModelData.ValidCategoryModel);
        }
    }
}
