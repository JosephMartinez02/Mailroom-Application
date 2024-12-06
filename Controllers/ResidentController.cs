using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MailroomApplication.Models;
using MvcPackage.Data;

namespace MailroomApplication.Controllers
{
    public class ResidentController : Controller
    {
        private readonly MvcPackageContext _context;

        public ResidentController(MvcPackageContext context)
        {
            _context = context;
        }

        // GET: Resident
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resident.ToListAsync());
        }

        // GET: Resident/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resident = await _context.Resident
                .FirstOrDefaultAsync(m => m.residentID == id);
            if (resident == null)
            {
                return NotFound();
            }

            return View(resident);
        }

        // GET: Resident/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resident/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("residentID,residentName,unitNumber,email")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resident);
        }

        // GET: Resident/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resident = await _context.Resident.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }
            return View(resident);
        }

        // POST: Resident/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("residentID,residentName,unitNumber,email")] Resident resident)
        {
            if (id != resident.residentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidentExists(resident.residentID))
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
            return View(resident);
        }

        // GET: Resident/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resident = await _context.Resident
                .FirstOrDefaultAsync(m => m.residentID == id);
            if (resident == null)
            {
                return NotFound();
            }

            return View(resident);
        }

        // POST: Resident/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resident = await _context.Resident.FindAsync(id);
            if (resident != null)
            {
                _context.Resident.Remove(resident);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResidentExists(int id)
        {
            return _context.Resident.Any(e => e.residentID == id);
        }
    }
}
