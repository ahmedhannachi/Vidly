using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = _context.Customers.Single(c => c.Id == id);
            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if( !ModelState.IsValid )
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        [HttpPut]
        public Customer UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Customer customerInDbContext = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDbContext == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDbContext.Name = customer.Name;
            customerInDbContext.BirthDay = customer.BirthDay;
            customerInDbContext.IsSubscribedToNewsletter= customer.IsSubscribedToNewsletter;
            customerInDbContext.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

            return customerInDbContext;
        }
        
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            Customer customerInDbContext = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDbContext == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDbContext);
            _context.SaveChanges();
        }
    }
}