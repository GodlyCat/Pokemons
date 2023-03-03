using AutoMapper;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryShortViewModel, Category>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<CountryShortViewModel, Country>().ReverseMap();
            CreateMap<Owner, OwnerViewModel>().ReverseMap();
            CreateMap<OwnerShortViewModel, Owner>().ReverseMap();
            CreateMap<Pokemon, PokemonViewModel>().ReverseMap();
            CreateMap<PokemonShortViewModel, Pokemon>().ReverseMap();
        }
    }
}
