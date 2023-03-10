using Microsoft.EntityFrameworkCore;
using PokemonBattle.DAL.Constants;
using PokemonBattle.DAL.Entities;
using System.Diagnostics.Metrics;
namespace PokemonBattle.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PokemonEntity> Pokemon { get; set; }
        public DbSet<PokemonOwnerEntity> PokemonOwners { get; set; }
        public DbSet<PokemonCategoryEntity> PokemonCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // for many to many (customazation w/out bd)
        {
            modelBuilder.Entity<PokemonCategoryEntity>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<PokemonCategoryEntity>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonCategoryEntity>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOwnerEntity>()
                .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwnerEntity>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonOwnerEntity>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(c => c.OwnerId);

            modelBuilder.Entity<CategoryEntity>().HasData(InitialData.GetCategories());
            modelBuilder.Entity<CountryEntity>().HasData(InitialData.GetCountries());
            modelBuilder.Entity<PokemonEntity>().HasData(InitialData.GetPokemons());
            modelBuilder.Entity<OwnerEntity>().HasData(InitialData.GetOwners());
        }
    }
}