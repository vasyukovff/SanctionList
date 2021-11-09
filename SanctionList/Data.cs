using Newtonsoft.Json;
using SanctionList.Dto;
using System.Net;

namespace SanctionList
{
    public class Data
    {
        public List<ObjectDto> GetData(string address = "https://data.opensanctions.org/datasets/latest/eu_fsf/targets.nested.json")
        {
            var objects = new List<ObjectDto>();

            WebClient webClient = new WebClient();

            var stream = webClient.OpenRead(address);
            var reader = new StreamReader(stream);
            var rows = reader.ReadToEnd().Split('\n');

            foreach (var row in rows)
            {
                if (string.IsNullOrEmpty(row))
                    continue;

                var newItem = JsonConvert.DeserializeObject<ObjectDto>(row);

                if (newItem != null)
                    objects.Add(newItem);
            }

            return objects;
        }
    }
}
