using Project2.Data;
using Project2.Models;
using Project2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Project2.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer CreateCustomer(Customer customer)
        {
            var result = _context.Customers.Add(customer);
            _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteCustomerById(string id)
        {
            var customer = _context.Customers.FirstOrDefault(u => u.CustId == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChangesAsync();
            }
        }

        public Customer GetCustomerById(string id)
        {
            return _context.Customers.FirstOrDefault(u => u.CustId == id);
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var result = _context.Customers
                .FirstOrDefault(e => e.CustId == e.CustId);

            if (result != null)
            {
                result.Name = customer.Name;
                result.CustomerGroupId = customer.CustomerGroupId;
                result.PhoneNumber = customer.PhoneNumber;
                result.EmailAddress = customer.EmailAddress;

                _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
