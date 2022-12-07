using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;

namespace EmployeeBackendAPI.Interface
{
    public interface ICountry_master
    {
        Task<Response> AddCountry(country_master country);
        Task<Response> UpdateCountry(country_master country);
        Task<List<country_master>> GetAllCountry();
        Task<country_master> GetCountry(int id);
    }
}
