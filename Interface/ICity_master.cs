using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;

namespace EmployeeBackendAPI.Interface
{
    public interface ICity_master
    {
        Task<Response> AddCity(city_master model);
        Task<Response> UpdateCity(city_master model);
        Task<Response> DeleteCity(int id);
        Task<List<city_master>> GetAllCity();
        Task<city_master> GetCity(int id);
        Task<Response> SaveCity(List<city> cities);
        Task<List<city>> GetAllCities(string state_code);
    }
}
