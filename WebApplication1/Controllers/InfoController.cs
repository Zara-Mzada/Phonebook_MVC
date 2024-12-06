using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class InfoController : Controller
{
    private readonly ILogger<InfoController> _logger;

    public InfoController(ILogger<InfoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Info()
    {
        return View();
    }
}