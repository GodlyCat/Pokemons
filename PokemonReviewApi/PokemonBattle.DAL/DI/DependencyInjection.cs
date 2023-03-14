﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonBattle.DAL.Data;
using PokemonBattle.DAL.Interfaces;
using PokemonBattle.DAL.Repositories;

namespace PokemonBattle.DAL.DI
{
    public static class DependencyInjection
    {
        public static void AddDependenciesDalLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddDbContext<DataContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }
    }
}
