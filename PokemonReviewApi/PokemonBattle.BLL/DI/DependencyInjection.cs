using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonBattle.BLL.Abstractions;
using PokemonBattle.BLL.Services;
using PokemonBattle.DAL.DI;

namespace PokemonBattle.BLL.DI
{
    public static class DependencyInjection
    {
        public static void AddDependenciesBllLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddDependenciesDalLayer(config);
        }
    }
}
