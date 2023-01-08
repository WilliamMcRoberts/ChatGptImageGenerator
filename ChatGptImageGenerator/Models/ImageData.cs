using Newtonsoft.Json;

namespace ChatGptImageGenerator.Models
{
    public class ImageData
    {
        [JsonProperty(propertyName: "url")]
        public string? Url { get; set; }
    }
}
