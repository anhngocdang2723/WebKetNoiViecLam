using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_KetNoiViecLam.Data;

namespace WebApp_KetNoiViecLam.Components
{
    public class UserManageService_KDuocDuyet : ViewComponent
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public UserManageService_KDuocDuyet(WebApp_KetNoiViecLamContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var _serviceContext = _context.Service.Include(s => s.Category).Include(s => s.Skill).Include(s => s.User);
            return View(_serviceContext.ToList());
        }
    }
}
