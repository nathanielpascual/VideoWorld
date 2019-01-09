using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoWorld.Models;
using VideoWorld.ViewModel;
namespace VideoWorld.Controllers
{
	public class MoviesController : Controller
	{
		// GET: Movies
		public ActionResult Index()
		{
			var movies = GetMovies();
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
			var movie = GetMovies().FirstOrDefault(x => x.Id == Id);
			return View(movie);
		}

		private IEnumerable<Movie> GetMovies()
		{
			return new List<Movie>
			{
				new Movie() { Id = 1, Name = "Equalizer" },
				new Movie() { Id = 2, Name = "Equalizer 2" },
				new Movie() { Id = 3, Name = "John Wick" },
				new Movie() { Id = 4, Name = "John Wick 2" }
			};
		}

		
	
	}
}