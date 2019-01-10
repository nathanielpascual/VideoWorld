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

		public ActionResult Random()
		{
			Movie movie = new Movie() { Id = 1, Name = "Equalizer" };

			var customers = new List<Customer>
			{
				new Customer{ Id=1,Name= "Customer1"},
				new Customer{ Id=1,Name= "Customer2"},
				new Customer{ Id=1,Name= "Customer3"},
				new Customer{ Id=1,Name= "Customer4"},
				new Customer{ Id=1,Name= "Customer5"},
				new Customer{ Id=1,Name= "Customer6"},
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};


			return View(viewModel);
		}

		[Route("movies/released/{year}/{month}")]
		public ActionResult ByReleaseDate(int year, int month) {

			return Content(year + "/" + month);
		}

		

		public ActionResult Details(int Id)
		{
			Movie movie = _context.Movies.Include(x=>x.Genre).FirstOrDefault(x => x.Id == Id);
			return View(movie);
		}

		

		
	
	}
}