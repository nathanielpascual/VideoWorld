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
			return View();
		}

		public ActionResult Random()
		{
			Movie movie = new Movie() { Id = 1, Name = "Equalizer" };

			var customers = new List<Customer>
			{
				new Customer{ Id=1,Name= "Customer1"},
				new Customer{ Id=1,Name= "Customer2"},
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};


			return View(viewModel);
		}

		[Route("movies/released/{year}/{month:regex(\\d{4}:range(1,12)}")]
		public ActionResult ByReleaseDate(int year, int month) {

			return Content(year + "/" + month);
		}
	}
}