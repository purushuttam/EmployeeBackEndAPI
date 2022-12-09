using EmployeeBackendAPI.Data;
using EmployeeBackendAPI.Interface;
using EmployeeBackendAPI.Model.Comman;
using EmployeeBackendAPI.Model.Department;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace EmployeeBackendAPI.Repository
{
    public class DepartmentRepo : IDepartmnet
    {
        private string _connectionString;
        private readonly EmployeeDbContext _context;
        Response response = new Response();
        public DepartmentRepo(IConfiguration configuration, EmployeeDbContext context)
        {
            _connectionString = configuration.GetConnectionString("EmployeeDbConnnection");
            _context = context;
        }

        public async Task<Department> GetDepartmentAPI(int DeptId)
        {
            var response = new Response();
            try
            {
                Department EmpVMObj = new Department();

                using (NpgsqlConnection con = new NpgsqlConnection(_connectionString))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("departmentbyid", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new NpgsqlParameter("_deptid", DeptId));
                        con.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            var cnt = reader.VisibleFieldCount;
                            while (reader.Read())
                            {
                                EmpVMObj = MapToValue(reader);
                            }
                        }
                    }
                }
                return EmpVMObj;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<Department>> GetAllDepartmentAPI()
        {
            /*List<Department> EmpVMObjList = new List<Department>();

            using (NpgsqlConnection con = new NpgsqlConnection(_connectionString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("spDepartment", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var cnt = reader.VisibleFieldCount;
                        while (reader.Read())
                        {
                            EmpVMObjList.Add(MapToValueList(reader));
                        }
                    }
                }
            }*/
            var EmpVMObjList = _context.departments.ToList();
            return EmpVMObjList;
        }

        public async Task<Response> AddDepartmentAPI(Department department)
        {
            try
            {
                if (department != null)
                {
                    department.department_id = KeyGen.GetKey();
                    _context.departments.Add(department);
                    int i = _context.SaveChanges();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "Department added succesfully";
                        return response;
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "Department not added";
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
            catch
            {
                return null;
            }
        }

        public async Task<Response> UpdateDepartmentAPI(Department department)
        {
            var response = new Response();
            try
            {
                if (department != null)
                {
                    _context.departments.Update(department);
                    int i = _context.SaveChanges();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "Department updated succesfully";
                        return response;
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "Invalid data";
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
            catch
            {
                return null;
            }
        }

        public async Task<Response> DeleteDepartmentAPI(int DeptId)
        {
            var response = new Response();
            try
            {
                if (DeptId != null)
                {
                    var em = _context.departments.Find(DeptId);
                    _context.departments.Remove(em);
                    int i = _context.SaveChanges();
                    if (i > 0)
                    {
                        response.resp = true;
                        response.respMsg = "Department updated succesfully";
                        return response;
                    }
                    else
                    {
                        response.resp = false;
                        response.respMsg = "Invalid data";
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
            catch
            {
                return null;
            }
        }

        private Department MapToValue(NpgsqlDataReader reader)
        {

            return new Department()
            {
                department_id = (string)reader["DeptId"],
                department_name = reader["DepartmentName"].ToString(),
                manager_name = reader["ManagerName"].ToString(),
            };
        }
        private Department MapToValueList(NpgsqlDataReader reader)
        {
            return new Department()
            {
                department_id = (string)reader["DeptId"],
                department_name = reader["DepartmentName"].ToString(),
                manager_name = reader["ManagerName"].ToString(),
            };
        }

        
        //------------- store procedure --------------
        /* private Department MapToValue(NpgsqlDataReader reader)
         {
             return new Department()
             {
                 DeptId = (int)reader["DeptId"],
                 DepartmentName = reader["DepartmentName"].ToString(),
                 ManagerName = reader["ManagerName"].ToString(),
                 Location = reader["Location"].ToString()
             };
         }
         private Department MapToValueList(NpgsqlDataReader reader)
         {
             return new Department()
             {
                 DeptId = (int)reader["DeptId"],
                 DepartmentName = reader["DepartmentName"].ToString(),
                 ManagerName = reader["ManagerName"].ToString(),
                 Location = reader["Location"].ToString()
             };
         }

         public Department GetDepartmentAPI(int DeptId)
         {
             Department EmpVMObj = new Department();

             using (NpgsqlConnection con = new NpgsqlConnection(_connectionString))
             {
                 using (NpgsqlCommand cmd = new NpgsqlCommand("departmentbyid", con))
                 {
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cmd.Parameters.Add(new NpgsqlParameter("_DeptId", DeptId));
                     con.Open();

                     using (var reader = cmd.ExecuteReader())
                     {
                         var cnt = reader.VisibleFieldCount;
                         while (reader.Read())
                         {
                             EmpVMObj = MapToValue(reader);
                         }
                     }
                 }
             }
             return EmpVMObj;
         }

         public List<Department> GetAllDepartmentAPI()
         {
             List<Department> EmpVMObjList = new List<Department>();

             using (NpgsqlConnection con = new NpgsqlConnection(_connectionString))
             {
                 using (NpgsqlCommand cmd = new NpgsqlCommand("spDepartment", con))
                 {
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     con.Open();

                     using (var reader = cmd.ExecuteReader())
                     {
                         var cnt = reader.VisibleFieldCount;
                         while (reader.Read())
                         {
                             EmpVMObjList.Add(MapToValueList(reader));
                         }
                     }
                 }
             }
             return EmpVMObjList;
         }

         public Department AddDepartmentAPI(Department department)
         {
             Department Ec = new Department();
             using (NpgsqlConnection con = new NpgsqlConnection(_connectionString))
             {
                 using (NpgsqlCommand cmd = new NpgsqlCommand("spDepartment", con))
                 {
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cmd.Parameters.Add(new NpgsqlParameter("@DeptId", department.DeptId));
                     cmd.Parameters.Add(new NpgsqlParameter("@DepartmentName", department.DepartmentName));
                     cmd.Parameters.Add(new NpgsqlParameter("@ManagerName", department.ManagerName));
                     cmd.Parameters.Add(new NpgsqlParameter("@Location", department.Location));
                     cmd.Parameters.Add(new NpgsqlParameter("@action", "insert"));
                     con.Open();
                     using (NpgsqlDataReader reader = cmd.ExecuteReader())
                     {
                         var cnt = reader.VisibleFieldCount;
                         while (reader.Read())
                         {
                             Ec = MapToValue(reader);
                         }
                     }
                 }
             }
             return Ec;
         }

         public Department UpdateDepartmentAPI(Department department)
         {
             Department Ec = new Department();
             using (NpgsqlConnection con = new NpgsqlConnection(_connectionString))
             {
                 using (NpgsqlCommand cmd = new NpgsqlCommand("spDepartment", con))
                 {
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cmd.Parameters.Add(new NpgsqlParameter("@DeptId", department.DeptId));
                     cmd.Parameters.Add(new NpgsqlParameter("@DepartmentName", department.DepartmentName));
                     cmd.Parameters.Add(new NpgsqlParameter("@ManagerName", department.ManagerName));
                     cmd.Parameters.Add(new NpgsqlParameter("@Location", department.Location));
                     cmd.Parameters.Add(new NpgsqlParameter("@action", "update"));
                     con.Open();
                     using (NpgsqlDataReader reader = cmd.ExecuteReader())
                     {
                         var cnt = reader.VisibleFieldCount;
                         while (reader.Read())
                         {
                             Ec = MapToValue(reader);
                         }
                     }
                 }
             }
             return Ec;
         }

         public Department DeleteDepartmentAPI(int DeptId)
         {
             Department EmpVMObj = new Department();

             using (NpgsqlConnection con = new NpgsqlConnection(_connectionString))
             {
                 using (NpgsqlCommand cmd = new NpgsqlCommand("spDepartment", con))
                 {
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cmd.Parameters.Add(new NpgsqlParameter("@DeptId", DeptId));
                     cmd.Parameters.Add(new NpgsqlParameter("@action", "delete"));
                     con.Open();

                     using (var reader = cmd.ExecuteReader())
                     {
                         var cnt = reader.VisibleFieldCount;
                         while (reader.Read())
                         {
                             EmpVMObj = MapToValue(reader);
                         }
                     }
                 }
             }
             return EmpVMObj;
         }*/
    }
}
