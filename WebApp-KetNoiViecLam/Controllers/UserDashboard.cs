using Microsoft.AspNetCore.Mvc;
using WebApp_KetNoiViecLam.Data;

namespace WebApp_KetNoiViecLam.Controllers
{
    public class UserDashboard : Controller
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public UserDashboard(WebApp_KetNoiViecLamContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Quan ly dich vu
        public IActionResult ManageService()
        {
            return View();
        }

        //Dang dich vu moi
        public IActionResult AddService() 
        {
            return View();
        }

        //Quan ly cong viec
        public IActionResult ManageJob()
        {
            return View();
        }

        //Dang dich vu moi
        public IActionResult AddJob()
        {
            return View();
        }
    }
}
