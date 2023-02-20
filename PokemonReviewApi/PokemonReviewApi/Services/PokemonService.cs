using AutoMapper;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Services.IServices;
using PokemonReviewApi.ViewModels;

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
        public PokemonShortViewModel UpdatePokemon(int pokeId, int ownerId, int categoryId, PokemonShortViewModel updatedPokemon)
        {
            var pokemonMap = _mapper.Map<PokemonEntity>(updatedPokemon);
            pokemonMap.Id = pokeId;
            _pokemonRepository.UpdatePokemon(ownerId, categoryId, pokemonMap);
            return updatedPokemon;
        }
    }
}
