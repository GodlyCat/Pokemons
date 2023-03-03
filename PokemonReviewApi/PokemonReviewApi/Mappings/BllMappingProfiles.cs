using AutoMapper;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Mappings
{
    public class BllMappingProfiles : Profile
    {
        public BllMappingProfiles()
        {
            CreateMap<Category, CategoryEntity>().ReverseMap();
            CreateMap<Country, CountryEntity>().ReverseMap();
            CreateMap<Owner, OwnerEntity>().ReverseMap();
            CreateMap<Pokemon, PokemonEntity>().ReverseMap();
        }
    }
}