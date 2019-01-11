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

		[HttpPost]
		public ActionResult Save(CustomerFormViewModel model)
		{
			Customer customer = model.Customer;

			if (customer.Id == 0)
				_context.Customers.Add(customer);
			else
			{
				var existingCustomer = _context.Customers.FirstOrDefault(x => x.Id == customer.Id);
				existingCustomer.Name = customer.Name;
				existingCustomer.MembershipTypeId = customer.MembershipTypeId;
				existingCustomer.BirthDate = customer.BirthDate;
				existingCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

			}
			_context.SaveChanges();

			return RedirectToAction("Index", "Customers");
		}

		public ActionResult New()
		{

			IEnumerable<MembershipType> memberShipType = _context.MembershipTypes.ToList();

			var viewModel = new CustomerFormViewModel()
			{
				MembershipTypes = memberShipType,
			};

			return View("CustomerForm",viewModel);
		}

		public ActionResult Edit(int Id)
		{
			var customer = _context.Customers.Include(x => x.MembershipType).FirstOrDefault(x => x.Id == Id);

			if (customer == null)
				return HttpNotFound();

			var viewModel = new CustomerFormViewModel()
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			return View("CustomerForm",viewModel);
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