using System.ComponentModel.DataAnnotations;

namespace EmployeeBackendAPI.Model.Department
{
    public class Department
    {
        public string department_id { get; set; }
        public string department_name { get; set; }
        public string manager_name { get; set; }
        public string location { get; set; }
        public int city_id { get; set; }
        public int state_id { get; set; }
        public int country_id { get; set; }
        public bool is_active { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public DateTime updated_on { get; set; }
        public string update_by { get; set; }
    }
}
