using LoginRegisterWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginRegisterWeb.Controllers
{
    public class LoginHomeController : Controller
    {
        private readonly ILogger<LoginHomeController> _logger;

        public LoginHomeController(ILogger<LoginHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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