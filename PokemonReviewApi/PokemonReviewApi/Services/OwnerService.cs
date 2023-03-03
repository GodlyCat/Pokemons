using AutoMapper;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Models;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Services.IServices;
using PokemonReviewApi.ViewModels;

namespace PokemonReviewApi.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public Owner CreateOwner(int countryId, Owner createdOwner)
        {
            var owners = _ownerRepository.GetOwners()
                .FirstOrDefault(c => c.LastName.Trim().ToUpper() == createdOwner.LastName.TrimEnd().ToUpper());

            var ownerMap = _mapper.Map<OwnerEntity>(createdOwner);
            ownerMap.Country = _countryRepository.GetCountryById(countryId);
            var ownerModelMap = _ownerRepository.CreateOwner(ownerMap);
            return _mapper.Map<Owner>(ownerModelMap);
        }

        public void DeleteOwner(int ownerId)
        {
            var ownerToDelete = _ownerRepository.GetOwnerById(ownerId);

            _ownerRepository.DeleteOwner(ownerToDelete);
        }

        public Owner? GetOwnerById(int ownerId)
        {
            var owner = _ownerRepository.GetOwnerById(ownerId);

            return _mapper.Map<Owner>(owner);
        }

        public List<Owner> GetOwners()
        {
            var owners = _ownerRepository.GetOwners();

            return _mapper.Map<List<Owner>>(owners);
        }

        public List<Owner> GetOwnersByCountryId(int countryId)
        {
            var owners = _ownerRepository.GetOwnersByCountryId(countryId);

            return _mapper.Map<List<Owner>>(owners);
        }

        public List<Owner> GetOwnersByPokeId(int pokeId)
        {
            var owners = _ownerRepository.GetOwnersByPokeId(pokeId);

            return _mapper.Map<List<Owner>>(owners);
        }

        public Owner UpdateOwner(int countryId, int ownerId, Owner updatedOwner)
        {
            var ownerMap = _mapper.Map<OwnerEntity>(updatedOwner);
            ownerMap.Id = ownerId;
            ownerMap.CountryId = countryId;
            var ownerModelMap = _ownerRepository.UpdateOwner(ownerMap);
            return _mapper.Map<Owner>(ownerModelMap);
        }
    }
}