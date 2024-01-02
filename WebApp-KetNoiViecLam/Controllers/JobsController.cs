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
    public class JobsController : Controller
    {
        private readonly WebApp_KetNoiViecLamContext _context;

        public JobsController(WebApp_KetNoiViecLamContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var webApp_KetNoiViecLamContext = _context.Job.Include(j => j.Category).Include(j => j.Skill).Include(j => j.User);
            return View(await webApp_KetNoiViecLamContext.ToListAsync());
        }
        public IActionResult ViewAllJob()
        {
            return View();
        }
        // GET: Jobs/UserViewDetails/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Job == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.Category)
                .Include(j => j.Skill)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details1(int? id)
        {
            if (id == null || _context.Job == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.Category)
                .Include(j => j.Skill)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CatId", "CatName");
            ViewData["SkillId"] = new SelectList(_context.Set<Skill>(), "SkillId", "SkillName");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "Email");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,CategoryId,JobTitle,JobDes,SkillId,DateCreated,Budget,Deadline,UserId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CatId", "CatName", job.CategoryId);
            ViewData["SkillId"] = new SelectList(_context.Set<Skill>(), "SkillId", "SkillName", job.SkillId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "Email", job.UserId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Job == null)
            {
                return NotFound();
            }

            var job = await _context.Job.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CatId", "CatName", job.CategoryId);
            ViewData["SkillId"] = new SelectList(_context.Set<Skill>(), "SkillId", "SkillName", job.SkillId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "Email", job.UserId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,CategoryId,JobTitle,JobDes,SkillId,DateCreated,Budget,Deadline,UserId")] Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CatId", "CatName", job.CategoryId);
            ViewData["SkillId"] = new SelectList(_context.Set<Skill>(), "SkillId", "SkillName", job.SkillId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "Email", job.UserId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Job == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.Category)
                .Include(j => j.Skill)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Job == null)
            {
                return Problem("Entity set 'WebApp_KetNoiViecLamContext.Job'  is null.");
            }
            var job = await _context.Job.FindAsync(id);
            if (job != null)
            {
                _context.Job.Remove(job);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
          return (_context.Job?.Any(e => e.JobId == id)).GetValueOrDefault();
        }
    }
}
