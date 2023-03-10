﻿using PokemonBattle.DAL.Entities;
using PokemonBattle.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonBattle.DAL.Data;

namespace PokemonBattle.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int Id)
        {
            return _context.Categories.Any(c => c.Id == Id);
        }

        public CategoryEntity CreateCategory(CategoryEntity createdCategory)
        {
            _context.Add(createdCategory);
            _context.SaveChanges();
            return createdCategory;
        }

        public void DeleteCategory(CategoryEntity deletedCategory)
        {
            _context.Remove(deletedCategory);
            _context.SaveChanges();
        }

        public IEnumerable<CategoryEntity> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public CategoryEntity? GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(e => e.Id == id);
        }

        public CategoryEntity UpdateCategory(CategoryEntity updatedCategory)
        {
            _context.Update(updatedCategory);
            _context.SaveChanges();
            return updatedCategory;
        }
    }
}
