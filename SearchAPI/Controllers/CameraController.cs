using Microsoft.AspNetCore.Mvc;
using SearchAPI.Model;

namespace SearchAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CameraController : ControllerBase
{
    private readonly ILogger<CameraController> _logger;
    private List<Camera> _cameras;

    public CameraController(ILogger<CameraController> logger)
    {
        _logger = logger;
        _cameras = System.IO.File.ReadAllLines("./data/cameras.csv")
            .Where(s => s.Contains(';'))
            .Skip(1)
            .Select(s => new Camera(s))
            .ToList();
    }

    [HttpGet]
    public IEnumerable<Camera> Get()
    {
        return _cameras;
    }

    [HttpGet("Search")]
    public IEnumerable<Camera> Search(string name)
    {
        if (string.IsNullOrEmpty(name))
            return _cameras;

        name = name.ToLower();

        return _cameras.Where(c => c.Name.ToLower().Contains(name));
    }
}
