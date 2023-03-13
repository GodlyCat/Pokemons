using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokemonBattle.DAL.Data;
using PokemonBattle.DAL.Interfaces;
using PokemonBattleApi;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());// mapper relies on automapper and DI nugets, +helper folder
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICountryRepository, CountryRepository>();
//builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
//builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
////builder.Services.AddScoped<IPokemonService, PokemonService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<ICountryService, CountryService>();
////builder.Services.AddScoped<IOwnerService, OwnerService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);// Without this timestamp it's stupid, postgres wants UTC type format

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
