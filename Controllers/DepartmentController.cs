using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmnet _departmnet;

        public DepartmentController(IDepartmnet departmnet)
        {
            _departmnet = departmnet;
        }
        [HttpGet]
        [Route("GetAllDepartment")]
        public async Task<List<Department>> GetAllDepartment()
        {
            return await _departmnet.GetAllDepartmentAPI();
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<Department> GetDepartment(int DeptId)
        {
            return await _departmnet.GetDepartmentAPI(DeptId);
        }

        [HttpPost]
        [Route("AddDepartmentAPI")]
        public async Task<Response> AddDepartmentAPI(Department department)
        {
            return await _departmnet.AddDepartmentAPI(department);
        }

        [HttpPost]
        [Route("UpdateDepartmentAPI")]
        public async Task<Response> UpdateDepartmentAPI(Department department)
        {
            return await _departmnet.UpdateDepartmentAPI(department);
        }

        [HttpDelete]
        [Route("DeleteDepartmentAPI")]
        public async Task<Response> DeleteDepartmentAPI(int DeptId)
        {
            return await _departmnet.DeleteDepartmentAPI(DeptId);
        }

    }
}
