using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int GenreId { get; set; }
        public GenreDto Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime AddedAt { get; set; }
        [Required]
        [Range(1, 20)]
        [NumberInStockBiggerOrEqualToNumberRented]
        public int NumberInStock { get; set; }
        [Required]
        [Range(1, 20)]
        public int NumberRented { get; set; }
    }

    public class NumberInStockBiggerOrEqualToNumberRented : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            MovieDto movieDto = (MovieDto) validationContext.ObjectInstance;
            if( movieDto.NumberInStock<movieDto.NumberRented )
                return new ValidationResult("Number in stock must be bigger than NumberRented");

            return ValidationResult.Success;
        }
    }
}