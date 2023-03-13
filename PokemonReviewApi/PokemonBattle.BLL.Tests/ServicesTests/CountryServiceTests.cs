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
        private readonly Mock<ICountryRepository> _countryRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly ICountryService _countryService;
        public CountryServiceTests()
        {
            _countryRepository = new Mock<ICountryRepository>();
            _mapper = new Mock<IMapper>();
            _countryService = new CountryService(_countryRepository.Object, _mapper.Object);
        }
        [Fact]
        public void CountryServiceGetCountries_ReturnsListOfCountries()
        {
            _countryRepository.Setup(cat => cat.GetCountries())
            .Returns(CountryEntityData.GetCountries());
            _mapper.Setup(m => m.Map<List<Country>>(It.IsAny<List<CountryEntity>>()))
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
            _countryRepository.Setup(catId => catId.GetCountryById(CountryEntityData.GetCountryEntity.Id))
            .Returns(CountryEntityData.GetCountryEntity);
            _mapper.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
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
            _countryRepository.Setup(catId => catId.GetCountryById(CountryEntityData.GetInvalidCountryEntity.Id))
            .Returns(CountryEntityData.GetInvalidCountryEntity);
            _mapper.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
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
            _countryRepository.Setup(catId => catId.GetCountryByOwnerId(CountryEntityData.GetCountryEntity.Id))
            .Returns(CountryEntityData.GetCountryEntity);
            _mapper.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.GetCountryModel);
            //Act
            var result = _countryService.GetCountryByOwnerId(CountryEntityData.GetCountryEntity.Id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetCountryModel);
        }
        public void GetCountryByOwnerId_InValidOwnerId_ShouldReturnModel()
        {
            //Arrange
            _countryRepository.Setup(catId => catId.GetCountryByOwnerId(CountryEntityData.GetInvalidCountryEntity.Id))
            .Returns(CountryEntityData.GetInvalidCountryEntity);
            _mapper.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
            .Returns(CountryModelData.GetInvalidCountryModel);
            //Act
            var result = _countryService.GetCountryByOwnerId(CountryEntityData.GetInvalidCountryEntity.Id);
            //Assert
            result.Id.Should().Be(0);
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetCountryModel);
        }
        public async Task DeleteCategory_ValidId_ShouldReturnModel()
        {
            // Arrange
            _mapper.Setup(m => m.Map<CountryEntity>(It.IsAny<Country>()))
                .Returns(CountryEntityData.GetCountryEntity);
            _countryRepository.Setup(r => r.CreateCountry(CountryEntityData.GetCountryEntity))
                .Returns(CountryEntityData.GetCountryEntity);
            _mapper.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
                .Returns(CountryModelData.GetCountryModel);
            int Id = CountryEntityData.GetCountryEntity.Id;
            var countryToDelete = CountryEntityData.GetCountryEntity;
            var countryModelToDelete = CountryModelData.GetCountryModel;
            _countryRepository.Setup(delId => delId.DeleteCountry(countryToDelete));

            // Act
            var result = _countryService.CreateCountry(countryModelToDelete);
            _countryService.DeleteCountry(CountryEntityData.GetCountryEntity.Id);

            // Assert
            _countryRepository.Verify(r => r.DeleteCountry(CountryEntityData.GetCountryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetCountryModel);
        }
        public async Task CreateCountry_CountryModel_ShouldReturnCValidModel()
        {
            // Arrange
            _mapper.Setup(m => m.Map<CountryEntity>(It.IsAny<Country>()))
                .Returns(CountryEntityData.GetCountryEntity);
            _countryRepository.Setup(r => r.CreateCountry(CountryEntityData.GetCountryEntity))
                .Returns(CountryEntityData.GetCountryEntity);
            _mapper.Setup(m => m.Map<Country>(It.IsAny<CountryEntity>()))
                .Returns(CountryModelData.GetCountryModel);

            // Act
            var result = _countryService.CreateCountry(CountryModelData.GetCountryModel);

            // Assert
            _countryRepository.Verify(r => r.CreateCountry(CountryEntityData.GetCountryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().BeEquivalentTo(CountryModelData.GetCountryModel);
        }
        [Fact]
        public async Task UpdateCountry_CountryModel_ShouldReturnValidModel()
        {
            //Arrange
            _mapper.Setup(m => m.Map<CountryEntity>(CountryModelData.UpdateCountryModel))
            .Returns(CountryEntityData.UpdateCountryEntity);
            _countryRepository.Setup(r => r.UpdateCountry(CountryEntityData.UpdateCountryEntity))
           .Returns(CountryEntityData.UpdateCountryEntity);
            _mapper.Setup(m => m.Map<Country>(CountryEntityData.UpdateCountryEntity))
                .Returns(CountryModelData.UpdateCountryModel);
            //Act
            var result = _countryService.UpdateCountry(CategoryModelData.UpdateCategoryModel.Id, CountryModelData.UpdateCountryModel);
            //Assert
            _countryRepository.Verify(r => r.UpdateCountry(CountryEntityData.UpdateCountryEntity));
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
            result.Should().NotBeEquivalentTo(CountryModelData.GetCountryModel);
        }
    }
}
