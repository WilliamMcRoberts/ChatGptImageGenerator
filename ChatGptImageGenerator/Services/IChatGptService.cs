using ChatGptImageGenerator.Models;

namespace ChatGptImageGenerator.Services
{
    public interface IChatGptService
    {
        Task<ImageResponse?> ExecuteImagePrompt(ImageRequest imageRequest);
    }
}