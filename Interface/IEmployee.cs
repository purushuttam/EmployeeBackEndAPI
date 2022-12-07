using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Employee;

namespace EmployeeBackendAPI.Interface
{
    public interface IEmployee
    {
        Task<Response> SaveEmployee(Employee employee);
        Task<Response> UpdateEmployee(Employee employee);
        Task<Response> DeleteEmployee(string employee_id);
        Task<List<Employee>> GetAllEmployee();
    }
}
