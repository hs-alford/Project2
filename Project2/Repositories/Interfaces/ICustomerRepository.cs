using Project2.Models;

namespace Project2.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(string customerId);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomerById(string customerId);
    }
}
