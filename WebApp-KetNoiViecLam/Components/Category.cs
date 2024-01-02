using Microsoft.AspNetCore.Mvc;
using WebApp_KetNoiViecLam.Data;

namespace WebApp_KetNoiViecLam.Components
{
    public class Category:ViewComponent
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public Category(WebApp_KetNoiViecLamContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ListOfCat = (from m in _context.Category 
                            where (m.IsActive == true) 
                            select m).ToList();
            return await Task.FromResult((IViewComponentResult)View(ListOfCat));
        }
    }
}
