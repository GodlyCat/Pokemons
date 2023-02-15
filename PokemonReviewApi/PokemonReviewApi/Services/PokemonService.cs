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
        public PokemonEntity CreatePokemon(int ownerId, int categoryId, PokemonEntity createdPokemon)
        {
            throw new NotImplementedException();
        }

        public void DeletePokemon(PokemonEntity deletedPokemon)
        {
            throw new NotImplementedException();
        }

        public PokemonViewModel UpdatePokemon(int ownerId, int categoryId, PokemonViewModel updatedPokemon)
        {
            var pokemonMap = _mapper.Map<PokemonEntity>(updatedPokemon);
            _pokemonRepository.UpdatePokemon(ownerId, categoryId, pokemonMap);
            return updatedPokemon;
        }
    }
}
