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
            _mapper = mapper;
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
        public PokemonViewModel GetPokemon(int pokeId)
        {
            return _mapper.Map<PokemonViewModel>(_pokemonService.GetPokemonById(pokeId));
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
        public List<PokemonViewModel> GetPokemonByOwner(int ownerId)
        {
            return _mapper.Map<List<PokemonViewModel>>(_pokemonService.GetPokemonsByOwnerId(ownerId));
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
        public PokemonViewModel GetPokemonByName(string Name)
        {
            return _mapper.Map<PokemonViewModel>(_pokemonService.GetPokemonByName(Name));
        }
        
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public PokemonViewModel CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonShortViewModel pokemonCreate)
        {
            var pokeMap = _mapper.Map<Pokemon>(pokemonCreate);
            var pokemonViewModelMap = _pokemonService.CreatePokemon(ownerId, catId, pokeMap);
            return _mapper.Map<PokemonViewModel>(pokemonViewModelMap);
        }

        [HttpPut("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public PokemonViewModel UpdatePokemon([FromQuery] int pokeId, [FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonShortViewModel updatedPokemon)
        {
            var pokeMap = _mapper.Map<Pokemon>(updatedPokemon);
            var pokemonViewModelMap = _pokemonService.UpdatePokemon(pokeId, ownerId, catId, pokeMap);
            return _mapper.Map<PokemonViewModel>(pokemonViewModelMap);
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
