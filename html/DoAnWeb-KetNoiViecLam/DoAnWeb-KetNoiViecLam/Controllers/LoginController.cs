using DoAnWeb_KetNoiViecLam.Models;
using DoAnWeb_KetNoiViecLam.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DoAnWeb_KetNoiViecLam.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
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
            if(account == null)
            {
                return NotFound();
            }

            string pw= Functions.MD5Password(account.Password);
            var check = _context.Accounts.Where(m => (m.Email == account.Email) && (m.Password==pw) ).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Invalid UserName or Password";
                return RedirectToAction("Index", "Login");
            }
            Functions._Message = string.Empty;
            Functions._id_user = check.id_user;
            Functions._Email=string.IsNullOrEmpty(check.Email)?string.Empty:check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}
