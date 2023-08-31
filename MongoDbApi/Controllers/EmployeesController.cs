using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbApi.Models;

namespace MongoDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public ActionResult<List<Employee>> Get() =>
        _employeeService.Get();

    [HttpGet("{id:length(24)}", Name = "GetEmployee")]
    public ActionResult<Employee> Get(string id)
    {
        var emp = _employeeService.Get(id);

        if (emp == null)
        {
            return NotFound();
        }

        return emp;
    }
        [HttpPost]
        public IActionResult  AddEmployee(Employee employee)
        {
            _employeeService.Post(employee);
            return Ok();
             
        }

        [HttpPut("{id}")]
        public IActionResult EditEmployee(int id, Employee employee)
        {
            _employeeService.Edit(id,employee);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.Delete(id);
            return Ok();

        }


    }
}  
