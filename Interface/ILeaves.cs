using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Employee;

namespace EmployeeBackendAPI.Interface
{
    public interface ILeaves
    {
        Task<Response> addleaves(List<leaves> model);
        Task<List<leaves>> getleaves();
        Task<leaves> getleavesByEmployee(int empid);
    }
}
