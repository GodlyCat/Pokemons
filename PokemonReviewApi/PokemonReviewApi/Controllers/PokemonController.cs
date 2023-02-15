﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Repository;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Services.IServices;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IPokemonService _pokemonService;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IPokemonService pokemonService, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _pokemonService = pokemonService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        public List<PokemonViewModel> GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonViewModel>>(_pokemonRepository.GetPokemons()); //without automapper - var pokemons = _pokemonRepository.GetPokemons()

            return pokemons;
        }

        [HttpGet("{pokeId:int}")]
        [ProducesResponseType(200, Type = typeof(PokemonEntity))]
        [ProducesResponseType(400)]
        public PokemonShortViewModel GetPokemon(int pokeId)
        {

            var pokemon = _mapper.Map<PokemonShortViewModel>(_pokemonRepository.GetPokemonById(pokeId));

            return pokemon;
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        [ProducesResponseType(400)]
        public List<PokemonEntity> GetPokemonByCategoryId(int categoryId)
        {
            var pokemons = _mapper.Map<List<PokemonEntity>>(_pokemonRepository.GetPokemonsByCategoryId(categoryId));

            return pokemons;
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(OwnerEntity))]
        [ProducesResponseType(400)]
        public List<PokemonShortViewModel> GetPokemonByOwner(int ownerId)
        {
            var owner = _mapper.Map<List<PokemonShortViewModel>>(_pokemonRepository.GetPokemonsByOwnerId(ownerId));

            return owner;
        }

        [HttpGet("{pokeId}/health")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public int GetPokemonHealth(int pokeId) //Action result is ~newish thing, uses polymorphism
        {
            var health = _pokemonRepository.GetPokemonHealth(pokeId);

            return health;
        }

        [HttpGet("{pokeId}/damage")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public int GetPokemonDamage(int pokeId)
        {
            var damage = _pokemonRepository.GetPokemonDamage(pokeId);
            return damage;
        }

        [HttpGet("{Name}")]
        public PokemonShortViewModel GetPokemonByName(string Name)
        {
            var pokeName = _mapper.Map<PokemonShortViewModel>(_pokemonRepository.GetPokemonByName(Name));
            return pokeName;
        }
        
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public PokemonShortViewModel CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonShortViewModel pokemonCreate)
        {

            var pokemons = _pokemonRepository.GetPokemons()
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper());

            var pokemonMap = _mapper.Map<PokemonEntity>(pokemonCreate);
            _pokemonRepository.CreatePokemon(ownerId, catId, pokemonMap);
            return pokemonCreate;
        }

        [HttpPut("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public PokemonViewModel UpdatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonViewModel updatedPokemon)
        {
            _pokemonService.UpdatePokemon(ownerId, catId, updatedPokemon);
            return updatedPokemon;
        }

        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public PokemonEntity DeletePokemon(int pokeId)
        {
            var pokemonToDelete = _pokemonRepository.GetPokemonById(pokeId);

            _pokemonRepository.DeletePokemon(pokemonToDelete);
            return pokemonToDelete;
        }

    }
}
