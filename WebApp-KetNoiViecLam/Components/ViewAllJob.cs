using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var webApp_KetNoiViecLamContext = _context.Service.Include(s => s.Category).Include(s => s.Skill).Include(s => s.User);
            return View(_context.Job.ToList());
        }
    }
}
