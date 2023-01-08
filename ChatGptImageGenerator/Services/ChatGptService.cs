using ChatGptImageGenerator.Models;
using Newtonsoft.Json;
using System.Text;

namespace ChatGptImageGenerator.Services
{
    public class ChatGptService : IChatGptService
    {
        public async Task<ImageResponse?> ExecuteImagePrompt(ImageRequest imageRequest)
        {
            using (HttpClient client = new HttpClient())
            {
                using var httpReq = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/images/generations");

                var apiKey = "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";

                httpReq.Headers.Add("Authorization", $"Bearer {apiKey}");
                var reqContent = JsonConvert.SerializeObject(imageRequest);


                try
                {
                    httpReq.Content = new StringContent(reqContent, Encoding.UTF8, "application/json");

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                using HttpResponseMessage? httpResponseMessage = await client.SendAsync(httpReq);

                if (httpResponseMessage != null && httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                    {
                        if (!string.IsNullOrWhiteSpace(responseString))
                        {
                            return JsonConvert.DeserializeObject<ImageResponse>(responseString);
                        }
                    }
                }
            }

            return null;
        }
    }
}
