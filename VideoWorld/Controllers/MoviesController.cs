using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoWorld.Models;
using VideoWorld.ViewModel;
namespace VideoWorld.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;
		// GET: Movies

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			_context.Dispose();
		}

		public ActionResult Index()
		{
			IEnumerable<Movie> movies = _context.Movies.Include(x => x.Genre);

			return View(movies);
		}

		public ActionResult New()
		{
			var genre = _context.Genres.ToList();

			var viewModel = new MovieFormViewModel()
			{
				Movie = new Movie(),
				Genres = genre
				
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult Save(MovieFormViewModel model)
		{
			var movie = model.Movie;
			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var existingMovie = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);
				existingMovie.Name = movie.Name;
				existingMovie.ReleasedDate = movie.ReleasedDate;
				existingMovie.GenreId = movie.GenreId;
				existingMovie.NumberInStock = movie.NumberInStock;
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");

		}


		public ActionResult Edit(int Id)
		{
			var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == Id);

			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel()
			{
				Movie = movie,
				Genres = _context.Genres.ToList()

			};

			return View("MovieForm",viewModel);
		}



		public ActionResult Details(int Id)
		{
			var movie = _context.Movies.Include(x=>x.Genre).FirstOrDefault(x => x.Id == Id);
			return View(movie);
		}

		

		
	
	}
}