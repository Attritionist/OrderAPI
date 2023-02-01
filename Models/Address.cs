﻿namespace PokemonReviewApp.Models
{
    public class Address
    {
        public int Id { get; set; } 
        public string City { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
