using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBackendAPI.Model.Employee
{
    public class Employee
    {
        [Key]
        public string? employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string? gender { get; set; }
        public DateTime dob { get; set; }
        public DateTime jd { get; set; }
        public string department_id { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created_on { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_on { get; set; }
        public string? updated_by { get; set; }
        [NotMapped]
        public List<EmployeeQualification> employee_Qualification { get; set; }
        [NotMapped]
        public List<EmployeeContactDetail> employee_Contact_Details { get; set; }
    }
    public class EmployeeQualification
    {
        [Key]
        public string? employee_qualification_id { get; set; }
        public string? employee_id { get; set; }
        public int qualification_year { get; set; }
        public string course_name { get; set; }
        public string last_qualification_university { get; set; }
        public string last_qualification_marks { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created_on { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_on { get; set; }
        public string? updated_by { get; set; }
    }
    public class EmployeeContactDetail
    {
        [Key]
        public string? employee_contact_details_id { get; set; }
        public string? employee_id { get; set; }
        public string mobile_no { get; set; }
        public string email_id { get; set; }
        public string address { get; set; }
        public string city_id { get; set; }
        public string state_id { get; set; }
        public string country_id { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created_on { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_on { get; set; }
        public string? updated_by { get; set; }
    }

    public class EmployeeSearch
    {
        public string? employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string department_name { get; set; }
        public bool? is_active { get; set; }
    }
}
