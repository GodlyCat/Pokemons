using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonBattle.BLL.Abstractions;
using PokemonBattle.BLL.Mappings;
using PokemonBattle.BLL.Services;
using PokemonBattle.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.BLL.DI
{
    public static class DependencyInjection
    {
        public static void AddDependenciesBllLayer(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
