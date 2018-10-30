using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime AddedAt { get; set; }
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberRented { get; set; }
    }

    public class NumberInStockBiggerOrEqualToNumberRented : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movie movieDto = (Movie)validationContext.ObjectInstance;
            if (movieDto.NumberInStock < movieDto.NumberRented)
                return new ValidationResult("Number in stock must be bigger than NumberRented");

            return ValidationResult.Success;
        }
    }
}