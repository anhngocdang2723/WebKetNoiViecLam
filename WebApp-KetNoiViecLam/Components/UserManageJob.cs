using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_KetNoiViecLam.Data;

namespace WebApp_KetNoiViecLam.Components
{
    public class UserManageJob:ViewComponent
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public UserManageJob(WebApp_KetNoiViecLamContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Job.ToList());
        }
    }
}
