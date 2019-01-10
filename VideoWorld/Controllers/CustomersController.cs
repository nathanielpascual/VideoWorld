using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoWorld.Models;
namespace VideoWorld.Controllers
{
	public class CustomersController : Controller
	{
		// GET: Customers

		private ApplicationDbContext _context;

		public CustomersController()
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
			IEnumerable<Customer> customers = _context.Customers.Include(x=>x.MembershipType);

			return View(customers);
		}
		[HttpGet]
		public ActionResult Details(int Id)
		{
			var customer = _context.Customers.Include(x => x.MembershipType).FirstOrDefault(x=>x.Id==Id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

	}
}