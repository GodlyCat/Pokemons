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
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerViewModel> GetOwners()
        {
            return _ownerService.GetOwners();
        }

        [HttpGet("Pokemon/{pokeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerShortViewModel> GetOwnersByPokeId(int pokeId)
        {
            return _ownerService.GetOwnersByPokeId(pokeId);
        }

        [HttpGet("Country/{countryId}")] //works pretty good
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerEntity>))]
        public List<OwnerShortViewModel> GetOwnersByCountryId(int countryId)
        {
            return _ownerService.GetOwnersByCountryId(countryId);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(OwnerEntity))]
        [ProducesResponseType(400)]
        public OwnerShortViewModel GetOwner(int ownerId)
        {
            return _ownerService.GetOwnerById(ownerId);
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
