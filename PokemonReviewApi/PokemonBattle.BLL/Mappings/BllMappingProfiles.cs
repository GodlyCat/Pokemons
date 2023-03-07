﻿using AutoMapper;
using PokemonBattleApi.Entities;
using PokemonBattle.BLL.Models;

namespace PokemonBattleApi.Mappings
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