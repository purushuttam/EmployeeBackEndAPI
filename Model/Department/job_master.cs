namespace EmployeeBackendAPI.Model.Department
{
    public class job_master
    {
        public string? job_master_id { get; set; }
        public string department_id { get; set; }
        public string designation_name { get; set; }
        public string designation_code { get; set; }
        public string job_description { get; set; }
        public decimal min_salary { get; set; }
        public decimal max_salary { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created_on { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_on { get; set; }
        public string? updated_by { get; set; }
    }
}
