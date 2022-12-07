using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;

namespace EmployeeBackendAPI.Interface
{
    public interface ICity_master
    {
        Task<Response> addCity(city_master model);
        Task<Response> updateCity(city_master model);
        Task<Response> deleteCity(int id);
        Task<List<city_master>> getAllCity();
        Task<city_master> getCity(int id);
    }
}
