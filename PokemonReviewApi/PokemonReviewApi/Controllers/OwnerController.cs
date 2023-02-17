using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, ICountryRepository countryRepository, IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _countryRepository = countryRepository;
            _pokemonRepository = pokemonRepository; 
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerViewModel> GetOwners()
        {
            var owners = _mapper.Map<List<OwnerViewModel>>(_ownerRepository.GetOwners());

            return owners;
        }

        [HttpGet("Pokemon/{pokeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerShortViewModel> GetOwnersByPokeId(int pokeId)
        {
            var owners = _mapper.Map<List<OwnerShortViewModel>>(_ownerRepository.GetOwnersByPokeId(pokeId));


            return owners;
        }

        [HttpGet("Country/{countryId}")] //works pretty good
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerShortViewModel> GetOwnersByCountryId(int countryId)
        {
            var owners = _mapper.Map<List<OwnerShortViewModel>>(_ownerRepository.GetOwnersByCountryId(countryId));

            return owners;
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(OwnerEntity))]
        [ProducesResponseType(400)]
        public OwnerShortViewModel GetOwner(int ownerId)
        {
            var owner = _mapper.Map<OwnerShortViewModel>(_ownerRepository.GetOwnerById(ownerId));

            return owner;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public OwnerEntity CreateOwner([FromQuery] int countryId, [FromBody] OwnerShortViewModel ownerCreate)
        {

            var owners = _ownerRepository.GetOwners()
                .FirstOrDefault(c => c.LastName.Trim().ToUpper() == ownerCreate.LastName.TrimEnd().ToUpper());

            var ownerMap = _mapper.Map<OwnerEntity>(ownerCreate);
            ownerMap.Country = _countryRepository.GetCountryById(countryId);
            _ownerRepository.CreateOwner(ownerMap);
            
            return owners;
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public OwnerShortViewModel UpdateOwner([FromQuery] int ownerId, [FromBody] OwnerShortViewModel updatedOwner)
        {
            var ownerMap = _mapper.Map<OwnerEntity>(updatedOwner);
            ownerMap.Id= ownerId;
            _ownerRepository.UpdateOwner(ownerMap);
            return updatedOwner;
        }

        [HttpDelete("{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public OwnerEntity DeleteOwner(int ownerId)
        {
            var ownerToDelete = _ownerRepository.GetOwnerById(ownerId);

            _ownerRepository.DeleteOwner(ownerToDelete);
            return ownerToDelete;
        }
        
    }
}
