﻿using PokemonReviewApi.Models;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services.IServices
{
    public interface ICountryService
    {
        List<Country> GetCountries();
        Country? GetCountryById(int id);
        Country? GetCountryByOwnerId(int ownerId);
        Country CreateCountry(Country createdCountry); //for create method, passing entire entity
        Country UpdateCountry(int countryId, Country updatedCountry);
        void DeleteCountry(int countryId);
    }
}
