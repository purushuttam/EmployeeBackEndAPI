using Newtonsoft.Json;

namespace EmployeeBackendAPI.Model.Area
{
    public class timezones
    {
        public string? zoneName { get; set; }
        [JsonProperty("gmtOffset")]
        public int? gmtOffset { get; set; }
        [JsonProperty("gmtOffsetName")]
        public string? gmtOffsetName { get; set; }
        public string? abbreviation { get; set; }
        public string? tzName { get; set; }
    }
}
