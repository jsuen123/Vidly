using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext(); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        [Route("Movies/")]
        public ActionResult Index()
        {
            var movies = _context.Movies;
            
            return View(movies);
        }

        // GET: Movies/Details/1
        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            return View(movie);
        }
    }
}