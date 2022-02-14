using Microsoft.AspNetCore.Mvc;
using SearchWebApp.Models;
using System.Diagnostics;
using System.Text.Json;

namespace SearchWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var result = await client.GetStringAsync("https://localhost:7029/camera");
            
            var cameras = JsonSerializer.Deserialize<List<Camera>>(result);

            IndexViewModel? vm = new();
            vm.Cameras = cameras ?? new List<Camera>();

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<JsonResult> GetCameras()
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var result = await client.GetStringAsync("https://localhost:7029/camera");

            return new JsonResult(result);
        }
    }
}