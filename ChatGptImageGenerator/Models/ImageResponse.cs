using Newtonsoft.Json;

namespace ChatGptImageGenerator.Models
{
    public class ImageResponse
    {
        [JsonProperty(propertyName: "created")]
        public long? Created { get; set; }
        [JsonProperty(propertyName: "data")]
        public ImageData[]? Data { get; set; }
    }
}
