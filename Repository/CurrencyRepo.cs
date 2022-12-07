using EmployeeBackendAPI.Data;
using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Area;
using EmployeeBackendAPI.Model.Comman;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackendAPI.Repository
{
    public class CurrencyRepo : ICurrency_master
    {
        private readonly EmployeeDbContext _context;
        Response response = new Response();
        public CurrencyRepo(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<Response> addCurrency(currency_master model)
        {
            try
            {
                if (model != null)
                {
                    model.is_active = true;
                    model.created_on = DateTime.UtcNow;
                    model.updated_on = DateTime.UtcNow;
                    await _context.currency_Master.AddAsync(model);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "currency added successfully";
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

        public async Task<List<currency_master>> getCurrencyList()
        {
            try
            {
                var res = await _context.currency_Master.ToListAsync();
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Response> updateCurrency(currency_master model)
        {
            try
            {
                if (model != null)
                {
                    model.is_active = true;
                    model.updated_on = DateTime.UtcNow;
                    _context.currency_Master.Update(model);
                    int i = await _context.SaveChangesAsync();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "currency updated successfully";
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
    }
}
