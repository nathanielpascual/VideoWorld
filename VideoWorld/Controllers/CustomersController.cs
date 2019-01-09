using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoWorld.Models;
namespace VideoWorld.Controllers
{
	public class CustomersController : Controller
	{
		// GET: Customers

		public ActionResult Index()
		{
			IEnumerable<Customer> customers = GetCustomers();

			return View(customers);
		}
		[HttpGet]
		public ActionResult Details(int Id)
		{
			var customer = GetCustomers().FirstOrDefault(x => x.Id == Id);

			return View(customer);
		}

		private IEnumerable<Customer> GetCustomers()
		{
			return new List<Customer>
			{
				new Customer() { Id = 1, Name="Nathaniel Pascual"},
				new Customer() { Id = 2, Name="Aileen Pascual"},
				new Customer() { Id = 3, Name="Victoria Pascual"},
				new Customer() { Id = 4, Name="Veronica Pascual"},
			};
		}
	}
}