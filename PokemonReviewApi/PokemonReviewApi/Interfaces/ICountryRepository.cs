﻿using PokemonBattleApi.Entities;
using System.Diagnostics.Metrics;

namespace PokemonBattleApi.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<CountryEntity> GetCountries();
        CountryEntity? GetCountryById(int id);
        CountryEntity? GetCountryByOwnerId(int ownerId);
        bool CountryExists(int id);
        CountryEntity CreateCountry(CountryEntity createdCountry); //for create method, passing entire entity
        CountryEntity UpdateCountry(CountryEntity updatedCountry);
        void DeleteCountry(CountryEntity deletedCountry);
    }
}