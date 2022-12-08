using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly ILeaves _leaves;

        public LeavesController(ILeaves leaves)
        {
            _leaves = leaves;
        }
        [HttpPost]
        [Route("Addleaves")]
        public async Task<IActionResult> Addleaves(leaves model)
        {
            var res = await _leaves.Addleaves(model);
            return Ok(res);
        }


        /*  [Authorize]*/
        [HttpGet]
        [Route("Getleaves")]
        public async Task<IActionResult> Getleaves()
        {
            var res = await _leaves.Getleaves();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetleavesByEmployee/{lid}")]
        public async Task<IActionResult> GetleavesByEmployee(int lid)
        {
            var res = await _leaves.GetleavesByEmployee(lid);
            return Ok(res);
        }
    }
}
