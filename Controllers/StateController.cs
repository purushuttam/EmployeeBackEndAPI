using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Area;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IState_master _state_Master;

        public StateController(IState_master state_Master)
        {
            _state_Master = state_Master;
        }
        [HttpPost]
        [Route("SaveState")]
        public async Task<IActionResult> SaveState(List<state> states)
        {
            var res = await _state_Master.SaveState(states);
            return Ok(res);
        }

        [HttpGet]
        [Route("GetStateBy/{Country_code}")]
        public async Task<IActionResult> GetStateByCountryCode(string Country_code)
        {
            var res = await _state_Master.GetAllState(Country_code);
            return Ok(res);
        }
    }
}
