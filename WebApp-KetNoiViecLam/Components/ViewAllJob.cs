using Microsoft.AspNetCore.Mvc;
using WebApp_KetNoiViecLam.Data;
using WebApp_KetNoiViecLam.Models;

namespace WebApp_KetNoiViecLam.Components
{
    public class ViewAllJob:ViewComponent
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public ViewAllJob(WebApp_KetNoiViecLamContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Job.ToList());
        }
    }
}
