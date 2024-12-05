using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_KetNoiViecLam.Data;

namespace WebApp_KetNoiViecLam.Components
{
    public class RatingJob:ViewComponent
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public RatingJob(WebApp_KetNoiViecLamContext context)
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
