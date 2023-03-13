using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;
using AutoMapper;
using PokemonBattle.DAL.Interfaces;
using PokemonBattle.BLL.Abstractions;
using PokemonBattle.BLL.Services;
using PokemonBattle.DAL.Repositories;
using PokemonBattle.BLL.Tests.TestData.Entities;
using PokemonBattle.BLL.Tests.TestData.Models;
using PokemonBattle.DAL.Entities;
using PokemonBattle.BLL.Models;

namespace PokemonBattle.BLL.Tests.ServicesTests
{
    public class CountryServiceTests
    {
        private readonly Mock<ICountryRepository> _countryRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ICountryService _countryService;
        public CountryServiceTests()
        {
            _countryRepositoryMock = new Mock<ICountryRepository>();
            _mapperMock = new Mock<IMapper>();
            _countryService = new CountryService(_countryRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void CountryServiceGetCountries_ReturnsListOfCountries()
        {
            _countryRepositoryMock.Setup(cat => cat.GetCountries())
            .Returns(CountryEntityData.GetCountries());
            _mapperMock.Setup(m => m.Map<List<Country>>(It.IsAny<List<CountryEntity>>()))
                .Returns(CountryModelData.GetCountries());
            //Act
            var result = _countryService.GetCountries();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Country>>();
        }

        [Fact]
        public void GetCountryById_ValidId_ShouldReturnModel()
        {
            //Arrange
            _countryRepositoryMock.Setup(catId => catId.GetCountryById(CountryEntityData.GetCountryEntity.Id))
            .Returns(CountryEntityData.GetCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.GetCountryModel);
            //Act
            var result = _countryService.GetCountryById(CountryEntityData.GetCountryEntity.Id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetCountryModel);
        }

        [Fact]
        public void GetCountryById_InvalidId_ShouldReturnModel()
        {
            //Arrange
            _countryRepositoryMock.Setup(catId => catId.GetCountryById(CountryEntityData.GetInvalidCountryEntity.Id))
            .Returns(CountryEntityData.GetInvalidCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.GetInvalidCountryModel);
            //Act
            var result = _countryService.GetCountryById(CountryEntityData.GetInvalidCountryEntity.Id);
            //Assert
            result.Id.Should().Be(0);
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetInvalidCountryModel);
        }

        [Fact]
        public void GetCountryByOwnerId_ValidOwnerId_ShouldReturnModel()
        {
            //Arrange
            _countryRepositoryMock.Setup(catId => catId.GetCountryByOwnerId(CountryEntityData.GetCountryEntity.Id))
            .Returns(CountryEntityData.GetCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.GetCountryModel);
            //Act
            var result = _countryService.GetCountryByOwnerId(CountryEntityData.GetCountryEntity.Id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetCountryModel);
        }

        [Fact]
        public void GetCountryByOwnerId_InvalidOwnerId_ShouldReturnModel()
        {
            //Arrange
            _countryRepositoryMock.Setup(catId => catId.GetCountryByOwnerId(CountryEntityData.GetInvalidCountryEntity.Id))
            .Returns(CountryEntityData.GetInvalidCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.GetInvalidCountryModel);
            //Act
            var result = _countryService.GetCountryByOwnerId(CountryEntityData.GetInvalidCountryEntity.Id);
            //Assert
            result.Id.Should().Be(0);
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetInvalidCountryModel);
        }

        [Fact]
        public async Task DeleteCountry_ValidId_ShouldReturnModel()
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<CountryEntity>(It.IsAny<Country>()))
                .Returns(CountryEntityData.GetCountryEntity);
            _countryRepositoryMock.Setup(r => r.CreateCountry(CountryEntityData.GetCountryEntity))
                .Returns(CountryEntityData.GetCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
                .Returns(CountryModelData.GetCountryModel);
            int Id = CountryEntityData.GetCountryEntity.Id;
            var countryToDelete = CountryEntityData.GetCountryEntity;
            var countryModelToDelete = CountryModelData.GetCountryModel;
            _countryRepositoryMock.Setup(delId => delId.DeleteCountry(countryToDelete));

            // Act
            var result = _countryService.CreateCountry(countryModelToDelete);
            _countryService.DeleteCountry(CountryEntityData.GetCountryEntity.Id);

            // Assert
            _countryRepositoryMock.Verify(r => r.DeleteCountry(It.IsAny<CountryEntity>()));
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetCountryModel);
        }

        [Fact]
        public async Task CreateCountry_ValidCountryModel_ShouldReturnCValidModel()
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<CountryEntity>(It.IsAny<Country>()))
                .Returns(CountryEntityData.GetCountryEntity);
            _countryRepositoryMock.Setup(r => r.CreateCountry(CountryEntityData.GetCountryEntity))
                .Returns(CountryEntityData.GetCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
                .Returns(CountryModelData.GetCountryModel);

            // Act
            var result = _countryService.CreateCountry(CountryModelData.GetCountryModel);

            // Assert
            _countryRepositoryMock.Verify(r => r.CreateCountry(CountryEntityData.GetCountryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetCountryModel);
        }

        [Fact]
        public async Task UpdateCountry_ValidCountryModel_ShouldReturnValidModel()
        {
            //Arrange
            _mapperMock.Setup(m => m.Map<CountryEntity>(CountryModelData.UpdateCountryModel))
            .Returns(CountryEntityData.UpdateCountryEntity);
            _countryRepositoryMock.Setup(r => r.UpdateCountry(CountryEntityData.UpdateCountryEntity))
           .Returns(CountryEntityData.UpdateCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(CountryEntityData.UpdateCountryEntity))
                .Returns(CountryModelData.UpdateCountryModel);
            //Act
            var result = _countryService.UpdateCountry(CategoryModelData.UpdateCategoryModel.Id, CountryModelData.UpdateCountryModel);
            //Assert
            _countryRepositoryMock.Verify(r => r.UpdateCountry(CountryEntityData.UpdateCountryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().NotBeEquivalentTo(CountryModelData.GetCountryModel);
        }
    }
}
