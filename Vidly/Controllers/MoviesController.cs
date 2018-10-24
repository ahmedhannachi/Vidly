using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
            return View(_context.Movies.Include(m => m.Genre).ToList());
        }


        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();


            return RedirectToAction("List", "Movies", _context.Movies.Include(m => m.Genre).ToList());
        }

        public ActionResult New()
        {
            MovieFormViewModel movieFormViewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieFormViewModel);
        }
    }
}