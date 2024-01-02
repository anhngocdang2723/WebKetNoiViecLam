using Microsoft.AspNetCore.Mvc;
using WebApp_KetNoiViecLam.Data;

namespace WebApp_KetNoiViecLam.Components
{
    public class BannerSearch:ViewComponent
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public BannerSearch(WebApp_KetNoiViecLamContext context)
        {
            _context = context;
        }

        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
