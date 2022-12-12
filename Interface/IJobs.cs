using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Department;

namespace EmployeeBackendAPI.Interface
{
    public interface IJobs
    {
        Task<Response> SaveJob(job_master job_Master);
        Task<Response> GetAllJobs();
        Task<Response> GetAllJobsByDepartmentId(string Department_id);
    }
}
