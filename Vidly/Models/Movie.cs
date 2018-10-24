using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedAt { get; set; }
        public int NumberInStock { get; set; }
    }
}