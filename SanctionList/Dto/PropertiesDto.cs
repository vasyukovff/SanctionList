using Newtonsoft.Json;

namespace SanctionList.Dto
{
    public class PropertiesDto
    {
        [JsonProperty("alias")]
        public string[] Alias { get; set; }

        [JsonProperty("sanctions")]
        public SanctionDto[] Sanctions { get; set; }

        //----------------//
        [JsonProperty("authority")]
        public string[] Authority { get; set; }

        [JsonProperty("country")]
        public string[] Country { get; set; }

        [JsonProperty("entity")]
        public string[] Entity { get; set; }

        [JsonProperty("program")]
        public string[] Program { get; set; }

        [JsonProperty("sourceUrl")]
        public string[] SourceUrl { get; set; }
    }
}
