using Newtonsoft.Json;
    namespace WebApp12_08.Models
    {
        public class Card
        {
            [JsonProperty("idList")]
            public string IdList { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("desc")]
            public string Description { get; set; }

        }
    }