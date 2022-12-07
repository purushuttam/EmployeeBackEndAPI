using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;

namespace EmployeeBackendAPI.Interface
{
    public interface ICountry_master
    {
        Task<Response> addCountry(country_master country);
        Task<Response> updateCountry(country_master country);
        Task<List<country_master>> getAllCountry();
        Task<country_master> getCountry(int id);
    }
}
