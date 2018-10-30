using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class AddRentalActionDto
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int[] MovieIds { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}