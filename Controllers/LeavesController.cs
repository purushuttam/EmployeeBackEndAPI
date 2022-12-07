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
        [Route("addleaves")]
        public async Task<IActionResult> addleaves(List<leaves> model)
        {
            var res = await _leaves.addleaves(model);
            return Ok(res);
        }


        /*  [Authorize]*/
        [HttpGet]
        [Route("getleaves")]
        public async Task<IActionResult> getleaves()
        {
            var res = await _leaves.getleaves();
            return Ok(res);
        }

        [HttpGet]
        [Route("getleavesByEmployee/lid")]
        public async Task<IActionResult> getleavesByEmployee(int lid)
        {
            var res = await _leaves.getleavesByEmployee(lid);
            return Ok(res);
        }
    }
}
