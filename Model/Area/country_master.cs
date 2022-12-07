using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBackendAPI.Model.Area
{
    public class country_master
    {
        [Key]
        public int country_id { get; set; }
        public string country_name { get; set; }
        public string country_code { get; set; }
        public string en { get; set; }
        public string ar { get; set; }
        public string fr { get; set; }
        public bool is_active { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
        public DateTime updated_on { get; set; }
        public string update_by { get; set; }
        [NotMapped]
        public currency_master currency_Master { get; set; }
        [NotMapped]
        public string json_currency_Master { get; set; }
    }
}
