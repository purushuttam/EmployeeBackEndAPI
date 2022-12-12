using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace EmployeeBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobs _jobs;

        public JobController(IJobs jobs)
        {
            _jobs = jobs;
        }

        [HttpPost]
        [Route("SaveJob")]
        public async Task<IActionResult> SaveJob(job_master job_Master)
        {
            var res = await _jobs.SaveJob(job_Master);
            return Ok(res);
        }

        [HttpGet]
        [Route("GetAllJob")]
        public async Task<IActionResult> GetAllJob()
        {
            var res = await _jobs.GetAllJobs();
            return Ok(res.respObj);
        }

        [HttpGet]
        [Route("GetAllJobByDId/{department_id}")]
        public async Task<IActionResult> GetAllJobs(string department_id)
        {
            var res = await _jobs.GetAllJobsByDepartmentId(department_id);
            return Ok(res);
        }
    }
}
