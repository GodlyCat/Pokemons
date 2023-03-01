using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.ViewModels;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Models;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Services.IServices;

namespace PokemonReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerViewModel> GetOwners()
        {
            return _mapper.Map<List<OwnerViewModel>>(_ownerService.GetOwners());
        }

        [HttpGet("Pokemon/{pokeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerViewModel> GetOwnersByPokeId(int pokeId)
        {
            return _mapper.Map<List<OwnerViewModel>>(_ownerService.GetOwnersByPokeId(pokeId));
        }

        [HttpGet("Country/{countryId}")] //works pretty good
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerViewModel> GetOwnersByCountryId(int countryId)
        {
            return _mapper.Map<List<OwnerViewModel>>(_ownerService.GetOwnersByCountryId(countryId));
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(OwnerEntity))]
        [ProducesResponseType(400)]
        public OwnerViewModel GetOwner(int ownerId)
        {
            return _mapper.Map<OwnerViewModel>(_ownerService.GetOwnerById(ownerId));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public OwnerViewModel CreateOwner([FromQuery] int countryId, [FromBody] OwnerShortViewModel ownerCreate)
        {
            var ownerMap = _mapper.Map<Owner>(ownerCreate);
            _ownerService.CreateOwner(countryId, ownerMap);
            return _mapper.Map<OwnerViewModel>(ownerMap);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public OwnerViewModel UpdateOwner([FromQuery] int countryId, [FromQuery] int ownerId, [FromBody] OwnerShortViewModel updatedOwner)
        {
            var ownerMap = _mapper.Map<Owner>(updatedOwner);
            _ownerService.UpdateOwner(countryId, ownerId, ownerMap);
            return _mapper.Map<OwnerViewModel>(ownerMap);
        }

        [HttpDelete("{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public Owner DeleteOwner(int ownerId)
        {
            _ownerService.DeleteOwner(ownerId);
            return null;
        }
    }
}
