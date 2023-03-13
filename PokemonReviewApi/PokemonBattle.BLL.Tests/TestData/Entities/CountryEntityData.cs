using PokemonBattle.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.BLL.Tests.TestData.Entities
{
    public static class CountryEntityData
    {
        public static List<CountryEntity> GetCategories()
        {
            var categoryList = new List<CountryEntity>
            {
                new() { Id=33,Name="Pakistan" },
                new() { Id=25,Name="Norway" },
                new() { Id=2,Name="Sweden" },
                new() { Id=12,Name="Austria" },
                new() { Id=31,Name="Canada" },
                new() { Id=5,Name="USA" },
                new() { Id=7,Name="Portugal" },
                new() { Id=28,Name="Spain" },
                new() { Id=19,Name="China" },
                new() { Id=15,Name="Japan" },
            };
            return categoryList;
        }
        internal static CountryEntity GetCountryEntity =
            new() { Id = 1, Name = "Brazil" };
        internal static CountryEntity UpdateCountryEntity =
            new() { Id = 3, Name = "Chile" };
    }
}
