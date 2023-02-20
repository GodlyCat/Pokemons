using AutoMapper;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Entities;

namespace PokemonReviewApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CategoryEntity, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryShortViewModel, CategoryEntity>().ReverseMap();

            CreateMap<CountryEntity, CountryViewModel>().ReverseMap();
            CreateMap<CountryShortViewModel, CountryEntity>().ReverseMap();

            CreateMap<OwnerEntity, OwnerViewModel>().ReverseMap();
            CreateMap<OwnerShortViewModel, OwnerEntity>().ReverseMap();

            CreateMap<PokemonEntity, PokemonViewModel>().ReverseMap();
            CreateMap<PokemonShortViewModel, PokemonEntity>().ReverseMap();
           
            
            
        }
    }
}
