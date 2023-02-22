using AutoMapper;
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
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        public List<PokemonViewModel> GetPokemons()
        {
            return _pokemonService.GetPokemons();
        }

        [HttpGet("{pokeId:int}")]
        [ProducesResponseType(200, Type = typeof(PokemonEntity))]
        [ProducesResponseType(400)]
        public PokemonShortViewModel GetPokemon(int pokeId)
        {
            return _pokemonService.GetPokemonById(pokeId);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        [ProducesResponseType(400)]
        public List<PokemonEntity> GetPokemonByCategoryId(int categoryId)
        {
            return _pokemonService.GetPokemonsByCategoryId(categoryId);
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(OwnerEntity))]
        [ProducesResponseType(400)]
        public List<PokemonShortViewModel> GetPokemonByOwner(int ownerId)
        {
            return _pokemonService.GetPokemonsByOwnerId(ownerId);
        }

        [HttpGet("{pokeId}/health")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public int GetPokemonHealth(int pokeId)
        {
            return _pokemonService.GetPokemonHealth(pokeId);
        }

        [HttpGet("{pokeId}/damage")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public int GetPokemonDamage(int pokeId)
        {
            return _pokemonService.GetPokemonDamage(pokeId);
        }

        [HttpGet("{Name}")]
        public PokemonShortViewModel GetPokemonByName(string Name)
        {
            return _pokemonService.GetPokemonByName(Name);
        }
        
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public PokemonShortViewModel CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonShortViewModel pokemonCreate)
        {
            _pokemonService.CreatePokemon(ownerId, catId, pokemonCreate);
            return pokemonCreate;
        }

        [HttpPut("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public PokemonShortViewModel UpdatePokemon([FromQuery] int pokeId, [FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonShortViewModel updatedPokemon)
        {
            _pokemonService.UpdatePokemon(pokeId, ownerId, catId, updatedPokemon);
            return updatedPokemon;
        }

        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public PokemonEntity DeletePokemon(int pokeId)
        {
            _pokemonService.DeletePokemon(pokeId);
            return null;
        }
    }
}
