using Microsoft.AspNetCore.Mvc;

namespace TestTaskAlkona.MVC.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() //две анкора: создать или найти документ
    {
        return View();
    }

    public IActionResult FindDocument()
    {
        return View();
    }

    public IActionResult DocumentInfo()
    {
        return View();
    }

    public IActionResult CreateDocument()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateDocument111()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}
