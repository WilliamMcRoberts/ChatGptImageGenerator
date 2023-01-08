using Newtonsoft.Json;

namespace ChatGptImageGenerator.Models
{
    public class ImageRequest
    {
        [JsonProperty(propertyName: "prompt")]
        public string? Prompt { get; set; }
        [JsonProperty(propertyName: "n")]
        public int TotalImages { get; set; }
        [JsonProperty(propertyName: "size")]
        public string? Size { get; set; }
    }
}
