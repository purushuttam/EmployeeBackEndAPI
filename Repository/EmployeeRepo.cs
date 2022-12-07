using EmployeeBackendAPI.Data;
using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Employee;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackendAPI.Repository
{
    public class EmployeeRepo : IEmployee
    {
        Response response = new Response();
        private readonly EmployeeDbContext _context;

        public EmployeeRepo(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<Response> SaveEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    response.resp = false;
                    response.respMsg = "Invalid data";
                    return response;
                }
                employee.employee_id = KeyGen.GetKey();
                employee.is_active = true;
                employee.created_by = "Admin";
                employee.created_on = DateTime.UtcNow;
                employee.updated_by = "admin";
                employee.updated_on = DateTime.UtcNow;
                await _context.employee.AddAsync(employee);
                int i = await _context.SaveChangesAsync();
                if (i > 0)
                {
                    response = await SaveQualification(employee.employee_Qualification, employee.employee_id);
                    if (!response.resp) { response.resp = false; response.respMsg = "Employee Saved without Qualification details and Contact details."; return response; }
                    response = await SaveContactDetails(employee.employee_Contact_Details, employee.employee_id);
                    if (response.resp)
                    {
                        response.resp = true;
                        response.respMsg = "Employee saved with Employee id : " + employee.employee_id;
                        response.respObj = employee;
                        return response;
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "employee not saved";
                        return response;
                    }

                }
                else
                {
                    response.resp = false;
                    response.respMsg = "employee not saved";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                response.respObj = null;
                return response;
            }
        }

        private async Task<Response> SaveContactDetails(List<EmployeeContactDetail> employee_Contact_Details, string employee_id)
        {
            try
            {
                if (employee_Contact_Details == null)
                {
                    response.resp = false;
                    response.respMsg = "Invalid data";
                    return response;
                }
                foreach (EmployeeContactDetail employee in employee_Contact_Details)
                {
                    employee.employee_contact_details_id = KeyGen.GetKey();
                    employee.employee_id = employee_id;
                    employee.is_active = true;
                    employee.created_by = "Admin";
                    employee.created_on = DateTime.UtcNow;
                    employee.updated_by = "admin";
                    employee.updated_on = DateTime.UtcNow;
                    await _context.employee_Contact_Details.AddAsync(employee);
                }
                int i = await _context.SaveChangesAsync();
                if (i > 0)
                {
                    response.resp = true;
                    response.respMsg = "Employee saved : ";
                    response.respObj = null;
                    return response;
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "employee not saved";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                response.respObj = null;
                return response;
            }
        }

        private async Task<Response> SaveQualification(List<EmployeeQualification> employee_Qualification, string employee_id)
        {
            try
            {
                if (employee_Qualification == null)
                {
                    response.resp = false;
                    response.respMsg = "Invalid data";
                    return response;
                }
                foreach (EmployeeQualification employee in employee_Qualification)
                {
                    employee.employee_qualification_id = KeyGen.GetKey();
                    employee.employee_id = employee_id;
                    employee.is_active = true;
                    employee.created_by = "Admin";
                    employee.created_on = DateTime.UtcNow;
                    employee.updated_by = "admin";
                    employee.updated_on = DateTime.UtcNow;
                    await _context.employee_Qualification.AddAsync(employee);
                }
                int i = await _context.SaveChangesAsync();
                if (i > 0)
                {
                    response.resp = true;
                    response.respMsg = "Employee saved : ";
                    response.respObj = null;
                    return response;
                }
                else
                {
                    response.resp = false;
                    response.respMsg = "employee not saved";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                response.respObj = null;
                return response;
            }
        }

        public async Task<Response> DeleteEmployee(string employee_id)
        {
            try
            {
               var data = await _context.employee.FindAsync(employee_id);
                if(data != null)
                {
                    _context.employee.Remove(data);
                    int i = await _context.SaveChangesAsync();
                    if(i > 0)
                    {
                        var data1 = await _context.employee_Qualification.FindAsync(employee_id);
                        if(data1 != null)
                        {
                            _context.employee_Qualification.Remove(data1);
                            int j = await _context.SaveChangesAsync();
                            if(j > 0)
                            {
                                var data2 = await _context.employee_Contact_Details.FindAsync(employee_id);
                                _context.employee_Contact_Details.Remove(data2);
                                int k = await _context.SaveChangesAsync();
                                if(k > 0)
                                {
                                    response.resp = true;
                                    response.respMsg = "employee deleted successfully";
                                    response.respObj = null;
                                    return response;
                                }
                            }
                        }
                    }
                }

                response.resp = false;
                response.respMsg = "Error";
                response.respObj = null;
                return response;
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                response.respObj = null;
                return response;
            }
        }

        public async Task<List<EmployeeSearch>> GetAllEmployee()
        {
            return null;
        }



        public async Task<Response> UpdateEmployee(Employee employee)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                response.resp = false;
                response.respMsg = ex.Message;
                response.respObj = null;
                return response;
            }
        }

        
    }
}
