using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnWeb_KetNoiViecLam.Models;
using DoAnWeb_KetNoiViecLam.Utilities;

namespace DoAnWeb_KetNoiViecLam.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(Account account)
        {
            if(account== null)
            {
                return NotFound();
            }
            var check = _context.Accounts.Where(m => m.Email == account.Email).FirstOrDefault();
            if(check != null)
            {
                Functions._MessageEmail = "Duplicate email";
                return RedirectToAction("Index","Register");
            }

            Functions._MessageEmail = string.Empty;
            account.Password = Functions.MD5Password(account.Password);
            _context.Add(account);
            _context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}
