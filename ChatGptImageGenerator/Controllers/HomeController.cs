using ChatGptImageGenerator.Models;
using ChatGptImageGenerator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace ChatGptImageGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChatGptService _chatGptService;

        public HomeController(ILogger<HomeController> logger, IChatGptService chatGptService)
        {
            _logger = logger;
            _chatGptService = chatGptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Chatgpt([FromForm] ChatFormRequest model)
        {
            if(model?.Prompt is null)
            {
                return RedirectToAction("index");
            }

            var imageRequest = new ImageRequest()
            {
                Prompt = model.Prompt,
                TotalImages = model.TotalImages,
                Size = model.Size ?? "256x256"
            };

            var response = await _chatGptService.ExecuteImagePrompt(imageRequest);

            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}