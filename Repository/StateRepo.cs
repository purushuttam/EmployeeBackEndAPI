using EmployeeBackendAPI.Data;
using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;

namespace EmployeeBackendAPI.Repository
{
    public class StateRepo : IState_master
    {
        private readonly EmployeeDbContext _context;
        Response response = new Response();

        public StateRepo(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<Response> AddState(state_master model)
        {
            try
            {
                if (model != null)
                {
                    model.is_active = true;
                    model.created_on = DateTime.UtcNow;
                    model.updated_on = DateTime.UtcNow;
                    await _context.state_Master.AddAsync(model);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "State added successfully";
                        return response;
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "Something went wrong";
                        return response;
                    }
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "Something went wrong";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                return response;
            }
        }

        public Task<Response> DeleteState(int stateId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<state>> GetAllState(string country_code)
        {
            var states = _context.state.Where(state => state.country_code.ToLower().Trim() == country_code.ToLower().Trim()).ToList();
            return states;
        }

        public async Task<Response> RemoveState(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var res = await _context.state_Master.FindAsync(Id);
                    _context.state_Master.Remove(res);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "State Deleted Successfully";
                        return response;
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "something went wrong";
                        return response;
                    }
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "something went wrong";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                return response;
            }
        }

        public async Task<Response> SaveState(List<state> states)
        {
            try
            {
                if(states == null) { response.resp = false; response.respMsg = "invalid data"; return response; }

                foreach (state state in states)
                {
                    /*state.type = String.IsNullOrEmpty((string?)state.type) ? String.Empty : state.type;*/
                    state.state_code = String.IsNullOrEmpty(state.state_code) ? String.Empty : state.state_code;
                    state.latitude = String.IsNullOrEmpty(state.latitude) ? String.Empty : state.longitude;
                    state.longitude = String.IsNullOrEmpty(state.longitude) ? String.Empty : state.longitude;
                    await _context.state.AddAsync(state);
                }
                int i = await _context.SaveChangesAsync();
                if (i > 0)
                {
                    response.resp = true;
                    response.respMsg = "State added successfully. Total " + i + " states.";
                    return response;
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "Something went wrong";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                return response;
            }
        }

        public async Task<Response> UpdateState(state_master model)
        {
            try
            {
                if (model != null)
                {
                    model.is_active = true;
                    model.created_on = DateTime.UtcNow;
                    model.updated_on = DateTime.UtcNow;
                    _context.state_Master.Update(model);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "State added successfully";
                        return response;
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "Something went wrong";
                        return response;
                    }
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "Invalid data";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                return response;
            }
        }
    }
}
