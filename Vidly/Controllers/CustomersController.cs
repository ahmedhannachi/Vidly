using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var ViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
            };

            return View("CustomerForm",ViewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("List", "Customers");
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            Customer customerInDbContext = _context.Customers.Single(c => c.Id == customer.Id);
            customerInDbContext.Name = customer.Name;
            customerInDbContext.BirthDay = customer.BirthDay;
            customerInDbContext.MembershipTypeId = customer.MembershipTypeId;
            customerInDbContext.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            _context.SaveChanges();
            return RedirectToAction("Edit", "Customers", new { Id = customer.Id });
        }

        private List<Customer> getCustomers()
        {
            return _context.Customers.Include(c=> c.MembershipType).ToList();
        }

        [Route("Customers/list")]
        public ActionResult List()
        {
            return View(this.getCustomers());
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            CustomerFormViewModel customerFormViewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes =  _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", customerFormViewModel);
        }
    }
}