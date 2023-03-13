using PokemonBattle.DAL.Entities;

namespace PokemonBattle.DAL.Constants
{
    public static class InitialData
    {
        public static List<CategoryEntity> GetCategories()
        {
            return new() {
            new() { Id = 1, Name = "Electric" },
            new() { Id = 2, Name = "Dark" },
            new() { Id = 3, Name = "Flying" }
            };

        }
        public static List<CountryEntity> GetCountries()
        {
            return new()  {
            new() { Id = 1, Name = "Kanto" },
            new() { Id = 2, Name = "Aroyan" },
            new() { Id = 3, Name = "Evelion" }
            };
        }
        public static List<OwnerEntity> GetOwners()
        {
            return new() {
            new() { Id = 1, FirstName = "Joe", LastName = "Biden", Team = "Valar", CountryId=1 },
            new() { Id = 2, FirstName = "Steven", LastName = "Seagull", Team = "Mystico", CountryId = 2 },
            new() { Id = 3, FirstName = "Peter", LastName = "Griffin", Team = "Instincto", CountryId = 3 }
            };
        }
        public static List<PokemonEntity> GetPokemons()
        {
            return new() {
            new() { Id = 1, Name = "Poki-Kun", Health = 100, Damage = 10 },
            new() { Id = 2, Name = "Hexor", Health = 250, Damage = 5 },
            new() { Id = 3, Name = "Gringo", Health = 150, Damage = 2 }
            };
        }
    }
}
