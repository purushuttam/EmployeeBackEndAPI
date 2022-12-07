using System.ComponentModel.DataAnnotations;

namespace EmployeeBackendAPI.Model.Department
{
    public class Department
    {
        [Key]
        public string department_id { get; set; }
        public string department_name { get; set; }
        public string manager_name { get; set; }
        public string city_id { get; set; }
        public string state_id { get; set; }
        public string country_id { get; set; }
        public bool is_active { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public DateTime updated_on { get; set; }
        public string updated_by { get; set; }
    }
}
