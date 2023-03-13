using PokemonBattle.BLL.Models;
using PokemonBattle.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.BLL.Tests.TestData.Models
{
    public static class CategoryModelData
    {
        public static List<Category> ValidCategories()
        {
            var categoryList = new List<Category>
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
        internal static Category ValidCategoryModel =
           new() { Id = 1, Name = "SteveJobbers" };
        internal static Category InvalidCategoryModel =
            new() { Id = 0, Name = "SteveGoblers" };
        internal static Category ValidUpdateCategoryModel =
           new() { Id = 3, Name = "Bozos" };
    }
}
