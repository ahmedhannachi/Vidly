using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
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

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            CustomerDto customerDto = Mapper.Map<Customer, CustomerDto>(customer);


            return Ok(customerDto);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            Customer customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), Mapper.Map<Customer,CustomerDto>(customer));
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Customer customerInDbContext = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDbContext == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDbContext);

            _context.SaveChanges();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerInDbContext));
        }
        
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            Customer customerInDbContext = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDbContext == null)
                return NotFound();

            _context.Customers.Remove(customerInDbContext);
            _context.SaveChanges();

            return Ok();
        }
    }
}