using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;

namespace EmployeeBackendAPI.Interface
{
    public interface IState_master
    {
        Task<Response> AddState(state_master state_Master);
        Task<Response> UpdateState(state_master state_Master);
        Task<Response> RemoveState(int stateId);
        Task<Response> DeleteState(int stateId);
        Task<Response> SaveState(List<state> state);
        Task<List<state>> GetAllState(string country_code);
    }
}
