using Microsoft.AspNetCore.Mvc;
using WebApp_KetNoiViecLam.Data;
using WebApp_KetNoiViecLam.Models;
using System.Linq;

namespace WebApp_KetNoiViecLam.Components
{
    public class PopularService : ViewComponent
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public PopularService(WebApp_KetNoiViecLamContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.Category.ToList();
            var reviews = _context.Review.ToList(); 
            var services = _context.Service.ToList(); 
            var users = _context.User.ToList();

            var viewModel = new ServiceViewModel
            {
                Categories = categories,
                Reviews = reviews,
                Services = services,
                Users = users
            };

            return View(viewModel);
        }
    }
}
