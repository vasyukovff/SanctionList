using Newtonsoft.Json;

namespace SanctionList.Dto
{
    public class ObjectDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("schema")]
        public string Schema { get; set; }

        [JsonProperty("properties")]
        public PropertiesDto Properties { get; set; }
    }
}
