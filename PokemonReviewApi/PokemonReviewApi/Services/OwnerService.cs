using AutoMapper;
using PokemonReviewApi.Entities;
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

        public OwnerShortViewModel CreateOwner(int countryId, OwnerShortViewModel createdOwner)
        {
            var owners = _ownerRepository.GetOwners()
                .FirstOrDefault(c => c.LastName.Trim().ToUpper() == createdOwner.LastName.TrimEnd().ToUpper());

            var ownerMap = _mapper.Map<OwnerEntity>(createdOwner);
            ownerMap.Country = _countryRepository.GetCountryById(countryId);
            _ownerRepository.CreateOwner(ownerMap);
            return createdOwner;
        }

        public void DeleteOwner(int ownerId)
        {
            var ownerToDelete = _ownerRepository.GetOwnerById(ownerId);

            _ownerRepository.DeleteOwner(ownerToDelete);
        }

        public OwnerShortViewModel? GetOwnerById(int ownerId)
        {
            var owner = _ownerRepository.GetOwnerById(ownerId);

            return _mapper.Map<OwnerShortViewModel>(owner);
        }

        public List<OwnerViewModel> GetOwners()
        {
            var owners = _ownerRepository.GetOwners();

            return _mapper.Map<List<OwnerViewModel>>(owners);
        }

        public List<OwnerShortViewModel> GetOwnersByCountryId(int countryId)
        {
            var owners = _ownerRepository.GetOwnersByCountryId(countryId);

            return _mapper.Map<List<OwnerShortViewModel>>(owners);
        }

        public List<OwnerShortViewModel> GetOwnersByPokeId(int pokeId)
        {
            var owners = _ownerRepository.GetOwnersByPokeId(pokeId);


            return _mapper.Map<List<OwnerShortViewModel>>(owners);
        }

        public OwnerShortViewModel UpdateOwner(int countryId, int ownerId, OwnerShortViewModel updatedOwner)
        {
            var ownerMap = _mapper.Map<OwnerEntity>(updatedOwner);
            ownerMap.Id = ownerId;
            ownerMap.CountryId = countryId;
            _ownerRepository.UpdateOwner(ownerMap);
            return updatedOwner;
        }
    }
}