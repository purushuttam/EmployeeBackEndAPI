using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Area;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountry_master _country_Master;

        public CountryController(ICountry_master country_Master)
        {
            _country_Master = country_Master;
        }

        [HttpPost]
        [Route("save_countries")]
        public async Task<IActionResult> saveCountries(List<countries> countries)
        {
            var res = await _country_Master.SaveCountries(countries);
            return Ok(res);
        }
        [HttpGet]
        [Route("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var res = await _country_Master.GetAllCountries();
            return Ok(res);
        }
    }
}
