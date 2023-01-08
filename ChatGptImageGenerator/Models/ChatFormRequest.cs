namespace ChatGptImageGenerator.Models
{
    public class ChatFormRequest
    {
        public string? Prompt { get; set; }
        public int TotalImages { get; set; }
        public string? Size { get; set; }
    }
}
