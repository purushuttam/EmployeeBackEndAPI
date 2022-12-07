using EmployeeBackendAPI.Data;
using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackendAPI.Repository
{
    public class CountryRepo : ICountry_master
    {
        private readonly string _configuration;
        private readonly EmployeeDbContext _context;
        Response response = new Response();
        public CountryRepo(IConfiguration configuration, EmployeeDbContext context)
        {
            _configuration = configuration.GetConnectionString("");
            _context = context;
        }

        public async Task<Response> AddCountry(country_master model)
        {
            try
            {
                if (model != null)
                {
                    model.is_active = true;
                    model.created_on = DateTime.UtcNow;
                    model.updated_on = DateTime.UtcNow;
                    await _context.country_master.AddAsync(model);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        var objCurrency = await SaveCurrency(model.currency_Master, model.country_id);
                        if (objCurrency.resp)
                        {
                            response.resp = true;
                            response.respMsg = "Country added successfully";
                            return response;
                        }
                        else
                        {
                            response.resp = false;
                            response.respMsg = "Country not added";
                            return response;
                        }
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "Country not added";
                        return response;
                    }

                }
                else
                {
                    response.resp = false;
                    response.respMsg = "invalid data";
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

        private async Task<Response> SaveCurrency(currency_master model, int country_id)
        {
            try
            {
                if (model != null)
                {
                    var obj = _context.currency_Master.Where(z => z.country_id.Equals(country_id)).AsNoTracking().FirstOrDefaultAsync();
                    if (obj != null)
                    {
                        _context.Entry(_context.currency_Master.Find(model.currency_id)).State = EntityState.Detached;
                    }
                    if (obj == null)
                    {
                        model.created_on = DateTime.UtcNow;
                        model.country_id = country_id;
                        await _context.currency_Master.AddAsync(model);
                    }
                    else
                    {
                        model.created_on = DateTime.UtcNow;
                        model.country_id = country_id;
                        _context.currency_Master.Update(model);
                    }
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "currency saved successfully";
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

        public async Task<List<country_master>> GetAllCountry()
        {
            try
            {
                var res = await _context.country_master.ToListAsync();
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<country_master> GetCountry(int id)
        {
            try
            {
                var res = await _context.country_master.FindAsync(id);
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Response> UpdateCountry(country_master model)
        {
            try
            {
                if (model != null)
                {
                    model.updated_on = DateTime.UtcNow;
                    _context.country_master.Update(model);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        var objCurrency = await SaveCurrency(model.currency_Master, model.country_id);
                        if (objCurrency.resp)
                        {
                            response.resp = true;
                            response.respMsg = "Courty updated succesfully";
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
