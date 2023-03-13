using AutoMapper;
using PokemonBattle.BLL.Models;
using PokemonBattle.DAL.Entities;
namespace PokemonBattle.BLL.Mappings
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