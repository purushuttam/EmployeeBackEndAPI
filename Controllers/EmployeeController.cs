using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpPost]
        [Route("saveEmployee")]
        public async Task<IActionResult> saveEmployee(Employee employee)
        {
            var res = await _employee.saveEmployee(employee);
            return Ok(res);
        }
    }
}
