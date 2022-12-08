using EmployeeBackendAPI.Data;
using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Employee;

namespace EmployeeBackendAPI.Repository
{
    public class LeavesRepo : ILeaves
    {
        private string _configuration;
        private readonly EmployeeDbContext _context;
        Response response = new Response();

        public LeavesRepo(IConfiguration configuration, EmployeeDbContext context)
        {
            _configuration = configuration.GetConnectionString("EmployeeDbConnnection");
            _context = context;
        }

        public Task<Response> Addleaves(leaves leave)
        {
            try
            {
                if (leave != null)
                {

                    leave.leaves_id = KeyGen.GetKey();
                    _context.leaves.Add(leave);
                    int i = _context.SaveChanges();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "leave applied successfully with leave Id : " + leave.leaves_id;
                        response.respObj = leave;
                        return Task.FromResult(response);
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "leave not applied";
                        return Task.FromResult(response);
                    }
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "leave not applied";
                    return Task.FromResult(response);
                }

            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                return Task.FromResult(response);
            }
        }

        public  Task<List<leaves>> Getleaves()
        {
            try
            {
                var res = _context.leaves.ToList();
                foreach (var leave in res)
                {
                    leave.employee_id = _context.employee.Find(leave.employee_id).first_name;
                }
                return Task.FromResult(res);
            }
            catch
            {
                return null;
            }
        }

        public Task<leaves> GetleavesByEmployee(int lid)
        {
            try
            {
                var res = _context.leaves.Find();
                return Task.FromResult(res);
            }
            catch
            {
                return null;
            }
        }
    }
}
