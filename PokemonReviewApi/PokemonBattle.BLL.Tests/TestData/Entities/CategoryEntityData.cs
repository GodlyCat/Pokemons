using System.Collections.Generic;

namespace PokemonBattle.BLL.Tests.TestData.Entities
{
    public static class CategoryEntityData
    {
        public static List<CategoryEntity> ValidCategories()
        {
            var categoryList = new List<CategoryEntity>
            {
                new() { Id=22,Name="Biggers" },
                new() { Id=11,Name="Tiggers" },
                new() { Id=2,Name="Siggers" },
                new() { Id=12,Name="Liggers" },
                new() { Id=31,Name="Piggers" },
                new() { Id=5,Name="Riggers" },
                new() { Id=7,Name="Higgers" },
                new() { Id=28,Name="Wingers" },
                new() { Id=19,Name="Triggers" },
                new() { Id=15,Name="Giggers" },
            };
            return categoryList;
        }
        internal static CategoryEntity ValidCategoryEntity =
            new() { Id = 1, Name = "SteveJobbers" };
        internal static CategoryEntity InvalidCategoryEntity =
            new() { Id = 0, Name = "SteveGoblers" };
        internal static CategoryEntity ValidUpdateCategoryEntity =
            new() { Id = 3, Name = "Bozos" };
    }
}
