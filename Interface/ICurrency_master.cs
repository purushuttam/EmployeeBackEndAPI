using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;

namespace EmployeeBackendAPI.Interface
{
    public interface ICurrency_master
    {
        Task<Response> addCurrency(currency_master currency);
        Task<Response> updateCurrency(currency_master currency);
        Task<List<currency_master>> getCurrencyList();
    }
}
