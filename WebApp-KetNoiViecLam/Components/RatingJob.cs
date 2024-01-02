using Microsoft.AspNetCore.Mvc;
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
            return View(_context.Job.ToList());
        }
    }
}
