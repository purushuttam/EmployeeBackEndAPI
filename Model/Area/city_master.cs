using System.ComponentModel.DataAnnotations;

namespace EmployeeBackendAPI.Model.Area
{
    public class city_master
    {
        [Key]
        public int city_id { get; set; }
        public string city_name { get; set; }
        public string city_code { get; set; }
        public int state_id { get; set; }
        public string en { get; set; }
        public string ar { get; set; }
        public string fr { get; set; }
        public bool is_active { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public DateTime updated_on { get; set; }
        public string update_by { get; set; }
    }
}
