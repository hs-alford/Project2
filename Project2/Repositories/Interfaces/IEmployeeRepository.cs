using Project2.Models;

namespace Project2.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(string id);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(string id);
        void UpdateEmployee(Employee employee);
    }
}
