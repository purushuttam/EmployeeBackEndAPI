using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeBackendAPI.Model.Area
{
    public class countries
    {
        [Key]
        public int? id { get; set; }
        public string? name { get; set; }
        public string? iso3 { get; set; }
        public string? iso2 { get; set; }
        public string? numeric_code { get; set; }
        public string? phone_code { get; set; }
        public string? capital { get; set; }
        public string? currency { get; set; }
        public string? currency_name { get; set; }
        public string? currency_symbol { get; set; }
        public string? tld { get; set; }
        public string? native { get; set; }
        public string? region { get; set; }
        public string? subregion { get; set; }
        [NotMapped]
        public List<timezones>? timezones { get; set; }
        public string? timezones_json { get; set; }
        [NotMapped]
        public translations? translations { get; set; }
        public string? translations_json { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
        public string? emoji { get; set; }
        public string? emojiU { get; set; }
    }
    public class state
    {
        public int id { get; set; }
        public string name { get; set; }
        public int country_id { get; set; }
        public string country_code { get; set; }
        public string? country_name { get; set; }
        public string? state_code { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
    }

}
