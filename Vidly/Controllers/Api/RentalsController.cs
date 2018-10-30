using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(AddRentalActionDto addRentalActionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Customer customer = _context.Customers.Single(c => c.Id == addRentalActionDto.CustomerId);

            List<Movie> Movies = _context.Movies.Where(m => addRentalActionDto.MovieIds.Contains(m.Id)).ToList();

            foreach (Movie movie in Movies)
            {
                if (movie.NumberInStock == movie.NumberRented)
                    return BadRequest("Movie unavailable");

                movie.NumberRented++;

                Rental rental = new Rental()
                {
                    CustomerId = customer.Id,
                    MovieId = movie.Id,
                    RentedDate = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }


            _context.SaveChanges();

            return Ok();
        }
    }
}
