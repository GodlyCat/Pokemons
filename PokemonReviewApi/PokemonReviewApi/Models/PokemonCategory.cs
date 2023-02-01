﻿using System.Diagnostics;

namespace PokemonReviewApi.Models
{
    public class PokemonCategory //join table
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }

    }
}
