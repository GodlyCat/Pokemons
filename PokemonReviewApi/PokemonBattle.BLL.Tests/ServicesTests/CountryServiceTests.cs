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
            .Returns(CountryEntityData.ValidCountries());
            _mapperMock.Setup(m => m.Map<List<Country>>(It.IsAny<List<CountryEntity>>()))
                .Returns(CountryModelData.ValidCountries());
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
            _countryRepositoryMock.Setup(catId => catId.GetCountryById(CountryEntityData.ValidCountryEntity.Id))
            .Returns(CountryEntityData.ValidCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.ValidCountryModel);
            //Act
            var result = _countryService.GetCountryById(CountryEntityData.ValidCountryEntity.Id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.ValidCountryModel);
        }

        [Fact]
        public void GetCountryById_InvalidId_ShouldReturnModel()
        {
            //Arrange
            _countryRepositoryMock.Setup(catId => catId.GetCountryById(CountryEntityData.InvalidCountryEntity.Id))
            .Returns(CountryEntityData.InvalidCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.InvalidCountryModel);
            //Act
            var result = _countryService.GetCountryById(CountryEntityData.InvalidCountryEntity.Id);
            //Assert
            result.Id.Should().Be(0);
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.InvalidCountryModel);
        }

        [Fact]
        public void GetCountryByOwnerId_ValidOwnerId_ShouldReturnModel()
        {
            //Arrange
            _countryRepositoryMock.Setup(catId => catId.GetCountryByOwnerId(CountryEntityData.ValidCountryEntity.Id))
            .Returns(CountryEntityData.ValidCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.ValidCountryModel);
            //Act
            var result = _countryService.GetCountryByOwnerId(CountryEntityData.ValidCountryEntity.Id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.ValidCountryModel);
        }

        [Fact]
        public void GetCountryByOwnerId_InvalidOwnerId_ShouldReturnModel()
        {
            //Arrange
            _countryRepositoryMock.Setup(catId => catId.GetCountryByOwnerId(CountryEntityData.InvalidCountryEntity.Id))
            .Returns(CountryEntityData.InvalidCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.InvalidCountryModel);
            //Act
            var result = _countryService.GetCountryByOwnerId(CountryEntityData.InvalidCountryEntity.Id);
            //Assert
            result.Id.Should().Be(0);
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.InvalidCountryModel);
        }

        [Fact]
        public async Task DeleteCountry_ValidId_ShouldReturnModel()
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<CountryEntity>(It.IsAny<Country>()))
                .Returns(CountryEntityData.ValidCountryEntity);
            _countryRepositoryMock.Setup(r => r.CreateCountry(CountryEntityData.ValidCountryEntity))
                .Returns(CountryEntityData.ValidCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
                .Returns(CountryModelData.ValidCountryModel);
            int Id = CountryEntityData.ValidCountryEntity.Id;
            var countryToDelete = CountryEntityData.ValidCountryEntity;
            var countryModelToDelete = CountryModelData.ValidCountryModel;
            _countryRepositoryMock.Setup(delId => delId.DeleteCountry(countryToDelete));

            // Act
            var result = _countryService.CreateCountry(countryModelToDelete);
            _countryService.DeleteCountry(CountryEntityData.ValidCountryEntity.Id);

            // Assert
            _countryRepositoryMock.Verify(r => r.DeleteCountry(It.IsAny<CountryEntity>()));
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.ValidCountryModel);
        }

        [Fact]
        public async Task CreateCountry_ValidCountryModel_ShouldReturnCValidModel()
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<CountryEntity>(It.IsAny<Country>()))
                .Returns(CountryEntityData.ValidCountryEntity);
            _countryRepositoryMock.Setup(r => r.CreateCountry(CountryEntityData.ValidCountryEntity))
                .Returns(CountryEntityData.ValidCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
                .Returns(CountryModelData.ValidCountryModel);

            // Act
            var result = _countryService.CreateCountry(CountryModelData.ValidCountryModel);

            // Assert
            _countryRepositoryMock.Verify(r => r.CreateCountry(CountryEntityData.ValidCountryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.ValidCountryModel);
        }

        [Fact]
        public async Task UpdateCountry_ValidCountryModel_ShouldReturnValidModel()
        {
            //Arrange
            _mapperMock.Setup(m => m.Map<CountryEntity>(CountryModelData.ValidUpdateCountryModel))
            .Returns(CountryEntityData.ValidUpdateCountryEntity);
            _countryRepositoryMock.Setup(r => r.UpdateCountry(CountryEntityData.ValidUpdateCountryEntity))
           .Returns(CountryEntityData.ValidUpdateCountryEntity);
            _mapperMock.Setup(m => m.Map<Country>(CountryEntityData.ValidUpdateCountryEntity))
                .Returns(CountryModelData.ValidUpdateCountryModel);
            //Act
            var result = _countryService.UpdateCountry(CategoryModelData.ValidUpdateCategoryModel.Id, CountryModelData.ValidUpdateCountryModel);
            //Assert
            _countryRepositoryMock.Verify(r => r.UpdateCountry(CountryEntityData.ValidUpdateCountryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().NotBeEquivalentTo(CountryModelData.ValidCountryModel);
        }
    }
}
