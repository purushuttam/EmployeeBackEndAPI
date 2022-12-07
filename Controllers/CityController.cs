using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Area;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICity_master _city_Master;

        public CityController(ICity_master city_Master)
        {
            _city_Master = city_Master;
        }
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [HttpPost]
        [Route("SaveCity")]
        public async Task<IActionResult> Savecity(List<city> cities)
        {
            var res = await _city_Master.SaveCity(cities);
            return Ok(res);
        }

        [HttpGet]
        [Route("GetCityBy/{state_id}")]
        public async Task<IActionResult> GetCityByStateId(string state_id)
        {
            var res = await _city_Master.GetAllCities(state_id);
            return Ok(res);
        }
    }
}
