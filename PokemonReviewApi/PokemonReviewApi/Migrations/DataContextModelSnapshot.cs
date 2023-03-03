﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PokemonBattleApi.Data;

#nullable disable

namespace PokemonReviewApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PokemonReviewApi.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electric"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dark"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Flying"
                        });
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kanto"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Aroyan"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Evelion"
                        });
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.OwnerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            FirstName = "Joe",
                            LastName = "Biden",
                            Team = "Valar"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            FirstName = "Steven",
                            LastName = "Seagull",
                            Team = "Mystico"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            FirstName = "Peter",
                            LastName = "Griffin",
                            Team = "Instincto"
                        });
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.PokemonCategoryEntity", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("PokemonId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PokemonCategories");
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.PokemonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Damage")
                        .HasColumnType("integer");

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pokemon");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Damage = 10,
                            Health = 100,
                            Name = "Poki-Kun"
                        },
                        new
                        {
                            Id = 2,
                            Damage = 5,
                            Health = 250,
                            Name = "Hexor"
                        },
                        new
                        {
                            Id = 3,
                            Damage = 2,
                            Health = 150,
                            Name = "Gringo"
                        });
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.PokemonOwnerEntity", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("PokemonId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("PokemonOwners");
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.OwnerEntity", b =>
                {
                    b.HasOne("PokemonReviewApi.Entities.CountryEntity", "Country")
                        .WithMany("Owners")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.PokemonCategoryEntity", b =>
                {
                    b.HasOne("PokemonReviewApi.Entities.CategoryEntity", "Category")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonReviewApi.Entities.PokemonEntity", "Pokemon")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.PokemonOwnerEntity", b =>
                {
                    b.HasOne("PokemonReviewApi.Entities.OwnerEntity", "Owner")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonReviewApi.Entities.PokemonEntity", "Pokemon")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.CategoryEntity", b =>
                {
                    b.Navigation("PokemonCategories");
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.CountryEntity", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.OwnerEntity", b =>
                {
                    b.Navigation("PokemonOwners");
                });

            modelBuilder.Entity("PokemonReviewApi.Entities.PokemonEntity", b =>
                {
                    b.Navigation("PokemonCategories");

                    b.Navigation("PokemonOwners");
                });
#pragma warning restore 612, 618
        }
    }
}
