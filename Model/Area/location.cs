using System.ComponentModel.DataAnnotations;

namespace EmployeeBackendAPI.Model.Area
{
    public class location
    {
        [Key]
        public int lid { get; set; }
        public string city { get; set; }
        public string countryCode { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public bool proxy { get; set; }
        public string query { get; set; }
    }
}
