using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Repository;
using PokemonReviewApi.Models;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Services.IServices;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonService pokemonService, IMapper mapper)
        {
            _pokemonService = pokemonService;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        public List<PokemonViewModel> GetPokemons()
        {
            return _mapper.Map<List<PokemonViewModel>>(_pokemonService.GetPokemons());
        }

        [HttpGet("{pokeId:int}")]
        [ProducesResponseType(200, Type = typeof(PokemonEntity))]
        [ProducesResponseType(400)]
        public PokemonShortViewModel GetPokemon(int pokeId)
        {
            return _mapper.Map<PokemonShortViewModel>(_pokemonService.GetPokemonById(pokeId));
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        [ProducesResponseType(400)]
        public List<PokemonViewModel> GetPokemonByCategoryId(int categoryId)
        {
            return _mapper.Map<List<PokemonViewModel>>(_pokemonService.GetPokemonsByCategoryId(categoryId));
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(OwnerEntity))]
        [ProducesResponseType(400)]
        public List<PokemonShortViewModel> GetPokemonByOwner(int ownerId)
        {
            return _mapper.Map<List<PokemonShortViewModel>>(_pokemonService.GetPokemonsByOwnerId(ownerId));
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
            return _mapper.Map<PokemonShortViewModel>(_pokemonService.GetPokemonByName(Name));
        }
        
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public PokemonShortViewModel CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonShortViewModel pokemonCreate)
        {
            var pokeMap = _mapper.Map<Pokemon>(pokemonCreate);
            _pokemonService.CreatePokemon(ownerId, catId, pokeMap);
            return pokemonCreate;
        }

        [HttpPut("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public PokemonShortViewModel UpdatePokemon([FromQuery] int pokeId, [FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonShortViewModel updatedPokemon)
        {
            var pokeMap = _mapper.Map<Pokemon>(updatedPokemon);
            _pokemonService.UpdatePokemon(pokeId, ownerId, catId, pokeMap);
            return updatedPokemon;
        }

        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public Pokemon DeletePokemon(int pokeId)
        {
            _pokemonService.DeletePokemon(pokeId);
            return null;
        }
    }
}
