using EmployeeBackendAPI.Data;
using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Department;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackendAPI.Repository
{
    public class JobsRepo : IJobs
    {
        private readonly EmployeeDbContext _context;
        Response response = new Response();

        public JobsRepo(EmployeeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Response> SaveJob(job_master job_Master)
        {
            try
            {
                if (job_Master != null)
                {
                    job_Master.job_master_id = KeyGen.GetKey();
                    job_Master.designation_code = _context.departments.Find(job_Master.department_id).department_name.Substring(0, 2).ToUpper();
                    job_Master.is_active = true;
                    job_Master.created_by = "admin";
                    job_Master.created_on = DateTime.UtcNow;
                    job_Master.updated_by = "admin";
                    job_Master.updated_on = DateTime.UtcNow;
                    await _context.job_master.AddAsync(job_Master);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "job saved successfully with job id : " + job_Master.job_master_id;
                        response.respObj = job_Master;
                        return response;
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "job not saved ";
                        return response;
                    }
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "job not saved ";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                return response;
            }
        }

        public async Task<Response> GetAllJobs()
        {
            try
            {
                var data = _context.job_master.ToList();
                if (data.Count > 0)
                {
                    response.resp = true;
                    response.respMsg = "Data Fetch Successfully";
                    response.respObj = data;
                    return response;
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "Data Not Fetched";
                    response.respObj = null;
                    return response;
                }
            }
            catch(Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                return response;
            }
        }

        public async Task<Response> GetAllJobsByDepartmentId(string Department_id)
        {
            try
            {
                var jobMaster = await _context.job_master.Where(z => z.department_id.Equals(Department_id)).ToListAsync();
                if(jobMaster.Count > 0)
                {
                    response.resp = true;
                    response.respMsg = "Data Fetch Successfully";
                    response.respObj = jobMaster;
                    return response;
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "Data Not Fetched";
                    response.respObj = null;
                    return response;
                }
            }
            catch(Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                return response;
            }
        }
    }
}
