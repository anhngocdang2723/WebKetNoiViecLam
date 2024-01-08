using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_KetNoiViecLam.Data;
using WebApp_KetNoiViecLam.Models;

namespace WebApp_KetNoiViecLam.Controllers
{
    public class ServicesController : Controller
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public ServicesController(WebApp_KetNoiViecLamContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var webApp_KetNoiViecLamContext = _context.Service.Include(s => s.Category).Include(s => s.Skill).Include(s => s.User);
            return View(await webApp_KetNoiViecLamContext.ToListAsync());
        }

        public IActionResult ViewAllService()
        {
            return View();
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .Include(s => s.Category)
                .Include(s => s.Skill)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }
        // GET: Services/Details1/5
        public async Task<IActionResult> Details1(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .Include(s => s.Category)
                .Include(s => s.Skill)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CatId", "CatName");
            ViewData["SkillId"] = new SelectList(_context.Set<Skill>(), "SkillId", "SkillName");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "Email");
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(ServiceStatus)));
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,CategoryId,ServiceTitle,ServiceDes,SkillId,DateCreated,Price,UserId,Status")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageService", "UserDashboard");
            }

            // Repopulate dropdowns in case of validation error
            ViewData["CategoryId"] = new SelectList(_context.Category, "CatId", "CatName", service.CategoryId);
            ViewData["SkillId"] = new SelectList(_context.Set<Skill>(), "SkillId", "SkillName", service.SkillId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "Email", service.UserId);
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(ServiceStatus)), service.Status);

            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CatId", "CatName", service.CategoryId);
            ViewData["SkillId"] = new SelectList(_context.Set<Skill>(), "SkillId", "SkillName", service.SkillId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "Email", service.UserId);
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(ServiceStatus)), service.Status);
            return View(service);
        }

        // POST: Services/Edit/5x
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,CategoryId,ServiceTitle,ServiceDes,SkillId,DateCreated,Price,UserId,Status")] Service service)
        {
            if (id != service.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ManageService", "UserDashboard");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CatId", "CatName", service.CategoryId);
            ViewData["SkillId"] = new SelectList(_context.Set<Skill>(), "SkillId", "SkillName", service.SkillId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "Email", service.UserId);
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(ServiceStatus)), service.Status);
            return View(service);
        }

        //Btn phe duyet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var service = await _context.Service.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            // Chuyển đổi trạng thái
            service.Status = (service.Status == ServiceStatus.ChuaDuyet) ? ServiceStatus.DaDuyet : ServiceStatus.ChuaDuyet;

            _context.Update(service);
            await _context.SaveChangesAsync();

            // Không chuyển hướng, trở lại trang hiện tại
            return RedirectToAction(nameof(Details), new { id });
        }

        //btn K phe duyet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatusToKhongPheDuyet(int id)
        {
            var service = await _context.Service.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            service.Status = ServiceStatus.KhongPheDuyet;
            _context.Update(service);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .Include(s => s.Category)
                .Include(s => s.Skill)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Service == null)
            {
                return Problem("Entity set 'WebApp_KetNoiViecLamContext.Service'  is null.");
            }
            var service = await _context.Service.FindAsync(id);
            if (service != null)
            {
                _context.Service.Remove(service);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
          return (_context.Service?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
