using Microsoft.AspNetCore.Mvc;

namespace WebApp_KetNoiViecLam.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
