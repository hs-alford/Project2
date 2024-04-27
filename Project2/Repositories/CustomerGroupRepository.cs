using Project2.Data;
using Project2.Models;
using Project2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Project2.Repositories
{
    public class CustomerGroupRepository : ICustomerGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerGroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public CustomerGroup CreateCustomerGroup(CustomerGroup customerGroup)
        {
            var result = _context.CustomerGroups.Add(customerGroup);
            _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteCustomerGroupById(string id)
        {
            var customerGroup = _context.CustomerGroups.FirstOrDefault(u => u.CustomerGroupId == id);
            if (customerGroup != null)
            {
                _context.CustomerGroups.Remove(customerGroup);
                _context.SaveChangesAsync();
            }
        }

        public CustomerGroup GetCustomerGroupById(string id)
        {
            return _context.CustomerGroups.FirstOrDefault(u => u.CustomerGroupId == id);
        }

        public List<CustomerGroup> GetCustomerGroups()
        {
            return _context.CustomerGroups.ToList();
        }

        public CustomerGroup UpdateCustomerGroup(CustomerGroup customerGroup)
        {
            var result = _context.CustomerGroups
                .FirstOrDefault(e => e.CustomerGroupId == e.CustomerGroupId);

            if (result != null)
            {
                result.GroupName = customerGroup.GroupName;

                _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
