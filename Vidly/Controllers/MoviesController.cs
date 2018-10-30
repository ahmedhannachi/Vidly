using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Movies/list")]
        public ActionResult List()
        {
            if(User.IsInRole(RoleName.canManageMovies))
                return  View(_context.Movies.Include(m => m.Genre).ToList());
            return View("ReadOnlyList",_context.Movies.Include(m => m.Genre).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Create(MovieDto movieDto)
        {
            _context.Movies.Add(Mapper.Map<MovieDto,Movie>(movieDto));
            _context.SaveChanges();


            return RedirectToAction("List", "Movies", _context.Movies.Include(m => m.Genre).ToList());
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult New()
        {
            MovieFormViewModel movieFormViewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Update(MovieDto movieDto)
        {
            Movie MovieInDbContext = _context.Movies.Single(m => m.Id == movieDto.Id);
            MovieInDbContext.Name = movieDto.Name;
            MovieInDbContext.AddedAt = movieDto.AddedAt;
            MovieInDbContext.GenreId = movieDto.GenreId;
            MovieInDbContext.NumberInStock = movieDto.NumberInStock;
            MovieInDbContext.ReleaseDate= movieDto.ReleaseDate;
            _context.SaveChanges();


            return RedirectToAction("Edit", "Movies", new { Id = movieDto.Id });
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Edit(int Id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();

            MovieFormViewModel movieFormViewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieFormViewModel);
        }
    }
}