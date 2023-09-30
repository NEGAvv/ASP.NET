using Newtonsoft.Json;

namespace myApp.entities
{
    public class User
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("gender")]
        public string? Gender { get; set; }
    }
}
