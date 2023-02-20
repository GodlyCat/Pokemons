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
            var pokemons = _pokemonRepository.GetPokemons(); //without automapper - var pokemons = _pokemonRepository.GetPokemons()

            return _mapper.Map<List<PokemonViewModel>>(pokemons);
        }

        [HttpGet("{pokeId:int}")]
        [ProducesResponseType(200, Type = typeof(PokemonEntity))]
        [ProducesResponseType(400)]
        public PokemonShortViewModel GetPokemon(int pokeId)
        {

            var pokemon = _pokemonRepository.GetPokemonById(pokeId);

            return _mapper.Map<PokemonShortViewModel>(pokemon);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        [ProducesResponseType(400)]
        public List<PokemonEntity> GetPokemonByCategoryId(int categoryId)
        {
            var pokemons = _pokemonRepository.GetPokemonsByCategoryId(categoryId);

            return _mapper.Map<List<PokemonEntity>>(pokemons);
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(OwnerEntity))]
        [ProducesResponseType(400)]
        public List<PokemonShortViewModel> GetPokemonByOwner(int ownerId)
        {
            var owner = _pokemonRepository.GetPokemonsByOwnerId(ownerId);

            return _mapper.Map<List<PokemonShortViewModel>>(owner);
        }

        [HttpGet("{pokeId}/health")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public int GetPokemonHealth(int pokeId)
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
            var pokeName = _pokemonRepository.GetPokemonByName(Name);
            return _mapper.Map<PokemonShortViewModel>(pokeName);
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
