using EmployeeBackendAPI.Data;
using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackendAPI.Repository
{
    public class CityRepo : ICity_master
    {
        private string _connectionString;
        private readonly string _configuration;
        private readonly EmployeeDbContext _context;
        Response response = new Response();
        public CityRepo(IConfiguration configuration,
            EmployeeDbContext context)
        {
            _configuration = configuration.GetConnectionString("EmployeeDbConnnection");
            _context = context;
        }

        public async Task<Response> AddCity(city_master model)
        {
            try
            {
                if (model != null)
                {
                    model.is_active = true;
                    model.created_on = DateTime.UtcNow;
                    model.updated_on = DateTime.UtcNow;
                    await _context.city_Master.AddAsync(model);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "City added successfully";
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

        public async Task<Response> UpdateCity(city_master model)
        {
            try
            {
                if (model != null)
                {
                    model.is_active = true;
                    model.updated_on = DateTime.UtcNow;
                    _context.city_Master.Update(model);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "City Updated successfully";
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

        public async Task<Response> DeleteCity(int id)
        {
            try
            {
                if (id > 0)
                {
                    var res = await _context.city_Master.FindAsync(id);
                    _context.city_Master.Remove(res);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "citi deleted successfully";
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

        public async Task<List<city_master>> GetAllCity()
        {
            try
            {
                var res = await _context.city_Master.ToListAsync();
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<city_master> GetCity(int id)
        {
            try
            {
                var res = await _context.city_Master.FindAsync(id);
                if (res == null)
                {
                    return null;
                }
                else
                {
                    return res;
                }

            }
            catch
            {
                return null;
            }
        }

        public async Task<Response> SaveCity(List<city> cities)
        {
            try
            {
                if (cities != null)
                {
                    foreach (var city in cities)
                    {
                        city.wikiDataId = String.IsNullOrEmpty(city.wikiDataId) ? string.Empty : city.wikiDataId;
                        await _context.city.AddAsync(city);
                    }
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "citi Added successfully. totoal city added : " + i;
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
                    response.respMsg = "Invalid data";
                    return response;
                }
            }
            catch(Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                return response;
            }
        }

        public async Task<List<city>> GetAllCities(string state_code)
        {
            var cities = _context.city.Where(z => z.state_code.ToLower().Trim() == state_code.ToLower().Trim()).ToList();
            return cities;
        }
    }
}
