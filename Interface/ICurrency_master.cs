using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;

namespace EmployeeBackendAPI.Interface
{
    public interface ICurrency_master
    {
        Task<Response> AddCurrency(currency_master currency);
        Task<Response> UpdateCurrency(currency_master currency);
        Task<List<currency_master>> GetCurrencyList();
    }
}
