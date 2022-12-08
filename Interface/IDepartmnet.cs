using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Department;

namespace EmployeeBackendAPI.Interface
{
    public interface IDepartmnet
    {
        Task<Department> GetDepartmentAPI(int DeptId);
        Task<List<Department>> GetAllDepartmentAPI();
        Task<Response> AddDepartmentAPI(Department department);
        Task<Response> UpdateDepartmentAPI(Department department);
        Task<Response> DeleteDepartmentAPI(int DeptId);
        Task<Response> SaveJob(job_master job_Master);
        Task<List<job_master>> GetAllJobs(string department_id);
    }
}
