using Project2.Models;

namespace Project2.Repositories.Interfaces
{
    public interface ICustomerGroupRepository
    {
        List<CustomerGroup> GetCustomerGroups();
        CustomerGroup GetCustomerGroupById(string customerGroupId);
        CustomerGroup CreateCustomerGroup(CustomerGroup customerGroup);
        CustomerGroup UpdateCustomerGroup(CustomerGroup customerGroup);
        void DeleteCustomerGroupById(string customerGroupId);
    }
}
