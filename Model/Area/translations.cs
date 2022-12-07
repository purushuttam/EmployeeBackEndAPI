using Newtonsoft.Json;

namespace EmployeeBackendAPI.Model.Area
{
    public class translations
    {
        public string? kr { get; set; }
        [JsonProperty("pt-BR")]
        public string? ptBR { get; set; }
        public string? pt { get; set; }
        public string? nl { get; set; }
        public string? hr { get; set; }
        public string? fa { get; set; }
        public string? de { get; set; }
        public string? es { get; set; }
        public string? fr { get; set; }
        public string? ja { get; set; }
        public string? it { get; set; }
        public string? cn { get; set; }
        public string? tr { get; set; }


    }
}
