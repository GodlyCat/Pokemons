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
