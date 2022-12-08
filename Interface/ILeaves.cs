using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Employee;

namespace EmployeeBackendAPI.Interface
{
    public interface ILeaves
    {
        Task<Response> Addleaves(leaves model);
        Task<List<leaves>> Getleaves();
        Task<leaves> GetleavesByEmployee(int empid);
    }
}
