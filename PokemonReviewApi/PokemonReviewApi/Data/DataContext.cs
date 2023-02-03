using Microsoft.EntityFrameworkCore;
using PokemonReviewApi.Models;
using System.Diagnostics.Metrics;

namespace PokemonReviewApi.Data
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

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity
                {
                    Id=1,
                    Name="Electric"
                },
                new CategoryEntity
                {
                    Id=2,
                    Name="Dark"
                },
                new CategoryEntity
                {
                    Id=3,
                    Name="Flying"
                }
             );
            modelBuilder.Entity<CountryEntity>().HasData(
                new CountryEntity
                {
                    Id = 1,
                    Name = "Kanto"
                },
                new CountryEntity
                {
                    Id = 2,
                    Name="Aroyan"
                },
                new CountryEntity
                {
                    Id = 3,
                    Name = "Evelion"
                }

            );
            
            modelBuilder.Entity<OwnerEntity>().HasData(
                new OwnerEntity
                {
                    Id = 1,
                    FirstName = "Joe",
                    LastName = "Biden",
                    Team = "Valar",
                    CountryId = 1
                },
                new OwnerEntity
                {
                    Id = 2,
                    FirstName = "Steven",
                    LastName = "Seagull",
                    Team = "Mystico",
                    CountryId=2
                },
                new OwnerEntity
                {
                    Id = 3,
                    FirstName = "Peter",
                    LastName = "Griffin",
                    Team = "Instincto",
                    CountryId = 3
                }
           );
            modelBuilder.Entity<PokemonEntity>().HasData(
                new PokemonEntity
                {
                    Id = 1,
                    Name = "Poki-Kun",
                    Health = 100,
                    Damage = 10
                },
                new PokemonEntity
                {
                    Id = 2,
                    Name = "Hexor",
                    Health = 250,
                    Damage = 5
                },
                new PokemonEntity
                {
                    Id = 3,
                    Name = "Gringo",
                    Health = 150,
                    Damage = 2
                }
            );
        }
        

    }
}