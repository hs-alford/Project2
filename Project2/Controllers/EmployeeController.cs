using Project2.Data;
using Project2.Models;
using Project2.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project2.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(ApplicationDbContext context, IEmployeeRepository employeeRepo)
        {
            _context = context;
            _employeeRepository = employeeRepo;
        }



        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(string id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(string id, [FromBody] Employee employee)
        {
            if (employee == null || id != employee.EmployeeId)
            {
                return BadRequest();
            }

            var existingEmployee = _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            _employeeRepository.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(string id)
        {
            var existingEmployee = _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            _employeeRepository.DeleteEmployee(id);
            return NoContent();
        }
    }
}
