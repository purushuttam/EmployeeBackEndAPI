using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;

namespace EmployeeBackendAPI.Interface
{
    public interface IState_master
    {
        Task<Response> addState(state_master state_Master);
        Task<Response> updateState(state_master state_Master);
        Task<Response> removeState(int stateId);
    }
}
