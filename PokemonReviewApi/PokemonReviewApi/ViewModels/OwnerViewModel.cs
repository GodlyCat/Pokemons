using PokemonReviewApi.Models;

namespace PokemonReviewApi.Dto
{
    public class OwnerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Team{ get; set; }
    }
}
