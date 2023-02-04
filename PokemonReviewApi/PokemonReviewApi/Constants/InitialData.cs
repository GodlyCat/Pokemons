using PokemonReviewApi.Entities;
namespace PokemonReviewApi.Constants
{
    public static class InitialData
    {
        public static List<CategoryEntity> GetCategories()
        {
            return new List<CategoryEntity> {
            new CategoryEntity
            { Id = 1, Name = "Electric" },
            new CategoryEntity
            { Id = 2, Name = "Dark" },
            new CategoryEntity
            { Id = 3, Name = "Flying" }
            };
            
        }
        public static List<CountryEntity> GetCountries()
        {
            return new List<CountryEntity> {
            new CountryEntity
            { Id = 1, Name = "Kanto" },
            new CountryEntity
            { Id = 2, Name = "Aroyan" },
            new CountryEntity
            { Id = 3, Name = "Evelion" }
            };
        }
        public static List<OwnerEntity> GetOwners()
        {
            return new List<OwnerEntity> {
            new OwnerEntity
            { Id = 1, FirstName = "Joe", LastName = "Biden", Team = "Valar", CountryId=1 },
            new OwnerEntity
            { Id = 2, FirstName = "Steven", LastName = "Seagull", Team = "Mystico", CountryId=2 },
            new OwnerEntity
            { Id = 3,FirstName = "Peter",LastName = "Griffin",Team = "Instincto",CountryId=3 }
            };
            
        }
        public static List<PokemonEntity> GetPokemons()
        {
            return new List<PokemonEntity> {
            new PokemonEntity
            { Id = 1, Name = "Poki-Kun", Health = 100, Damage = 10 },
            new PokemonEntity
            { Id = 2, Name = "Hexor", Health = 250, Damage = 5 },
            new PokemonEntity
            { Id = 3, Name = "Gringo", Health = 150, Damage = 2 }
            };
        }
       
    }
}
