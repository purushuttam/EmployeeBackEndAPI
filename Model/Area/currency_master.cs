using System.ComponentModel.DataAnnotations;

namespace EmployeeBackendAPI.Model.Area
{
    public class currency_master
    {
        [Key]
        public int currency_id { get; set; }
        public string currency_name { get; set; }
        public string currency_code { get; set; }
        public int country_id { get; set; }
        public bool is_active { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public DateTime updated_on { get; set; }
        public string update_by { get; set; }
    }
}
