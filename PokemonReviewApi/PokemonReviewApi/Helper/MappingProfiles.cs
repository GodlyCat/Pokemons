using AutoMapper;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Entities;

namespace PokemonReviewApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CategoryEntity, CategoryViewModel>();
            CreateMap<CategoryViewModel, CategoryEntity>();
            CreateMap<CountryEntity, CountryViewModel>();
            CreateMap<CountryViewModel, CountryEntity>();
            CreateMap<OwnerEntity, OwnerViewModel>();
            CreateMap<OwnerViewModel, OwnerEntity>();
            CreateMap<PokemonEntity, PokemonViewModel>();
            CreateMap<PokemonViewModel, PokemonEntity>();
            CreateMap<PokemonShortViewModel, PokemonEntity>();
            CreateMap<OwnerShortViewModel, OwnerEntity>();
            CreateMap<CountryShortViewModel, CountryEntity>();
            CreateMap<CategoryShortViewModel, CategoryEntity>();
        }
    }
}
