using PokemonBattle.DAL.Data;
using PokemonBattle.DAL.Entities;
using PokemonBattle.DAL.Interfaces;

namespace PokemonBattle.DAL.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public CountryEntity CreateCountry(CountryEntity createdCountry)
        {
            _context.Add(createdCountry);
            _context.SaveChanges();
            return createdCountry;
        }

        public void DeleteCountry(CountryEntity deletedCountry)
        {
            _context.Remove(deletedCountry);
            _context.SaveChanges();
        }

        public IEnumerable<CountryEntity> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public CountryEntity? GetCountryById(int id)
        {
            return _context.Countries.FirstOrDefault(cou => cou.Id == id);
        }

        public CountryEntity? GetCountryByOwnerId(int ownerId)
        {
            return _context.Owners.Where(ow => ow.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public CountryEntity UpdateCountry(CountryEntity updatedCountry)
        {
            _context.Update(updatedCountry);
            _context.SaveChanges();
            return updatedCountry;
        }
    }
}