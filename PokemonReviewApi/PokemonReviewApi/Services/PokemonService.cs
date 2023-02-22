using AutoMapper;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Services.IServices;
using PokemonReviewApi.ViewModels;
using System.Xml.Linq;

namespace PokemonReviewApi.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        public PokemonService(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }
        public PokemonShortViewModel CreatePokemon(int ownerId, int categoryId, PokemonShortViewModel createdPokemon)
        {
            var pokemons = _pokemonRepository.GetPokemons()
               .FirstOrDefault(c => c.Name.Trim().ToUpper() == createdPokemon.Name.TrimEnd().ToUpper());

            var pokemonMap = _mapper.Map<PokemonEntity>(createdPokemon);
            _pokemonRepository.CreatePokemon(ownerId, categoryId, pokemonMap);
            return createdPokemon;
        }
        public void DeletePokemon(int pokeId)
        {
            var pokemonToDelete = _pokemonRepository.GetPokemonById(pokeId);

            _pokemonRepository.DeletePokemon(pokemonToDelete);
        }

        public PokemonShortViewModel? GetPokemonById(int id)
        {
            var pokemon = _pokemonRepository.GetPokemonById(id);

            return _mapper.Map<PokemonShortViewModel>(pokemon);
        }

        public PokemonShortViewModel? GetPokemonByName(string name)
        {
            var pokeName = _pokemonRepository.GetPokemonByName(name);
            return _mapper.Map<PokemonShortViewModel>(pokeName);
        }

        public int GetPokemonDamage(int pokeId)
        {
            var damage = _pokemonRepository.GetPokemonDamage(pokeId);
            return damage;
        }

        public int GetPokemonHealth(int pokeId)
        {
            var health = _pokemonRepository.GetPokemonHealth(pokeId);

            return health;
        }

        public List<PokemonViewModel> GetPokemons()
        {
            var pokemons = _pokemonRepository.GetPokemons();

            return _mapper.Map<List<PokemonViewModel>>(pokemons);
        }

        public List<PokemonEntity> GetPokemonsByCategoryId(int categoryId)
        {
            var pokemons = _pokemonRepository.GetPokemonsByCategoryId(categoryId);

            return _mapper.Map<List<PokemonEntity>>(pokemons);
        }

        public List<PokemonShortViewModel> GetPokemonsByOwnerId(int ownerId)
        {
            var owner = _pokemonRepository.GetPokemonsByOwnerId(ownerId);

            return _mapper.Map<List<PokemonShortViewModel>>(owner);
        }

        public PokemonShortViewModel UpdatePokemon(int pokeId, int ownerId, int categoryId, PokemonShortViewModel updatedPokemon)
        {
            var pokemonMap = _mapper.Map<PokemonEntity>(updatedPokemon);
            pokemonMap.Id = pokeId;
            _pokemonRepository.UpdatePokemon(ownerId, categoryId, pokemonMap);
            return updatedPokemon;
        }
    }
}