using Microsoft.AspNetCore.Mvc;
using WebApp_KetNoiViecLam.Data;
using WebApp_KetNoiViecLam.Models;

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

        //JS lay status DV
        public IActionResult GetServicesByStatus(ServiceStatus status)
        {
            var services = _context.Service.Where(s => s.Status == status).ToList();
            return PartialView("_ServicePartial", services);
        }

    }
}
