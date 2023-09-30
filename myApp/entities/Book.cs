using Newtonsoft.Json;

namespace myApp.entities
{
    public class Book
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("author")]
        public string? Author { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }
    }
}
