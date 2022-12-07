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
        public async Task<IActionResult> SaveEmployee(Employee employee)
        {
            var res = await _employee.SaveEmployee(employee);
            return Ok(res);
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var res = await _employee.GetAllEmployee();
            return Ok(res);
        }
    }
}
