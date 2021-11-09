using Newtonsoft.Json;

namespace SanctionList.Dto
{
    public class SanctionDto
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("datasets")]
        public string[] Dataset { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("properties")]
        public PropertiesDto Properties { get; set; }
    }
}
