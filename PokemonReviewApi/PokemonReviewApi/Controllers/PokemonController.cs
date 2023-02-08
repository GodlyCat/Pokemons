using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Repository;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IOwnerRepository ownerRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonViewModel>>(_pokemonRepository.GetPokemons()); //without automapper - var pokemons = _pokemonRepository.GetPokemons()
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{pokeId:int}")]
        [ProducesResponseType(200, Type = typeof(PokemonEntity))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();

            var pokemon = _mapper.Map<PokemonViewModel>(_pokemonRepository.GetPokemonById(pokeId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryId(int categoryId)
        {
            var pokemons = _mapper.Map<List<PokemonViewModel>>(_pokemonRepository.GetPokemonsByCategoryId(categoryId));
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(pokemons);
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(OwnerEntity))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }
            var owner = _mapper.Map<List<PokemonViewModel>>(_pokemonRepository.GetPokemonsByOwnerId(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet("{pokeId}/health")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonHealth(int pokeId) //Action result is ~newish thing, uses polymorphism
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }

            var health = _pokemonRepository.GetPokemonHealth(pokeId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(health);
        }

        [HttpGet("{pokeId}/damage")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId) //Action result is ~newish thing, uses polymorphism
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }

            var damage = _pokemonRepository.GetPokemonDamage(pokeId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(damage);
        }

        [HttpGet("{Name}")]
        public IActionResult GetPokemonByName(string Name)
        {
            var pokeName = _mapper.Map<PokemonViewModel>(_pokemonRepository.GetPokemonByName(Name));
            return Ok(pokeName);
        }
        
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemonGay([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonShortViewModel pokemonCreate)
        {
            if (pokemonCreate == null)
                return BadRequest(ModelState);

            var pokemons = _pokemonRepository.GetPokemons()
                .Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (pokemons != null)
            {
                ModelState.AddModelError("", "Pokemon already Exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<PokemonEntity>(pokemonCreate);
            _pokemonRepository.CreatePokemon(ownerId, catId, pokemonMap);
            return Ok("Successfully created");
        }

        [HttpPut("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePokemon(int pokeId, [FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonViewModel updatedPokemon)
        {
            if (updatedPokemon == null)
                return BadRequest(ModelState);

            if (pokeId != updatedPokemon.Id)
                return BadRequest(ModelState);

            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<PokemonEntity>(updatedPokemon);
            _pokemonRepository.UpdatePokemon(ownerId, catId, pokemonMap);
            return NoContent();
        }

        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            var pokemonToDelete = _pokemonRepository.GetPokemonById(pokeId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _pokemonRepository.DeletePokemon(pokemonToDelete);
            return NoContent();
        }

    }
}
