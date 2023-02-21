using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Services.IServices;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, IOwnerService ownerService, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _ownerService = ownerService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerViewModel> GetOwners()
        {
            var owners = _ownerRepository.GetOwners();

            return _mapper.Map<List<OwnerViewModel>>(owners);
        }

        [HttpGet("Pokemon/{pokeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerShortViewModel> GetOwnersByPokeId(int pokeId)
        {
            var owners = _ownerRepository.GetOwnersByPokeId(pokeId);


            return _mapper.Map<List<OwnerShortViewModel>>(owners);
        }

        [HttpGet("Country/{countryId}")] //works pretty good
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerShortViewModel> GetOwnersByCountryId(int countryId)
        {
            var owners = _ownerRepository.GetOwnersByCountryId(countryId);

            return _mapper.Map<List<OwnerShortViewModel>>(owners);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(OwnerEntity))]
        [ProducesResponseType(400)]
        public OwnerShortViewModel GetOwner(int ownerId)
        {
            var owner = _ownerRepository.GetOwnerById(ownerId);

            return _mapper.Map<OwnerShortViewModel>(owner);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public OwnerShortViewModel CreateOwner([FromQuery] int countryId, [FromBody] OwnerShortViewModel ownerCreate)
        {
            _ownerService.CreateOwner(countryId, ownerCreate);
            return ownerCreate;
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public OwnerShortViewModel UpdateOwner([FromQuery] int countryId, [FromQuery] int ownerId, [FromBody] OwnerShortViewModel updatedOwner)
        {
            _ownerService.UpdateOwner(countryId, ownerId, updatedOwner);
            return updatedOwner;
        }

        [HttpDelete("{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public OwnerEntity DeleteOwner(int ownerId)
        {
            _ownerService.DeleteOwner(ownerId);
            return null;
        }
    }
}
