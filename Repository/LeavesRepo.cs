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

        public async Task<Response> addleaves(List<leaves> model)
        {
            try
            {
                if (model != null)
                {
                    foreach (var leave in model)
                    {
                        leave.leaves_id = KeyGen.GetKey();
                        _context.leaves.Add(leave);
                    }

                    int i = _context.SaveChanges();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "leave applied successfully";
                        return response;
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "leave not applied";
                        return response;
                    }
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "leave not applied";
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

        public async Task<List<leaves>> getleaves()
        {
            try
            {
                var res = _context.leaves.ToList();
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<leaves> getleavesByEmployee(int lid)
        {
            try
            {
                var res = _context.leaves.Find();
                return res;
            }
            catch
            {
                return null;
            }
        }
    }
}
