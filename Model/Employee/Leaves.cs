using System.ComponentModel.DataAnnotations;

namespace EmployeeBackendAPI.Model.Employee
{
    public class leaves
    {
        [Key]
        public string leaves_id { get; set; }
        public string employee_id { get; set; }
        public DateTime sdate { get; set; }
        public DateTime edate { get; set; }
        public string reason { get; set; }
        /*[NotMapped]
        public string json_leaves { get; set; }*/
    }
}
