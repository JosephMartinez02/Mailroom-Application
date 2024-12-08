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
    public class ResidentPackageController : Controller
    {
        private readonly MvcPackageContext _context;

        public ResidentPackageController(MvcPackageContext context)
        {
            _context = context;
        }

        // GET: ResidentPackage
        public async Task<IActionResult> Index()
        {
            var mvcPackageContext = _context.ResidentPackage.Include(r => r.Package).Include(r => r.Resident);
            return View(await mvcPackageContext.ToListAsync());
        }

        // GET: ResidentPackage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residentPackage = await _context.ResidentPackage
                .Include(r => r.Package)
                .Include(r => r.Resident)
                .FirstOrDefaultAsync(m => m.residentID == id);
            if (residentPackage == null)
            {
                return NotFound();
            }

            return View(residentPackage);
        }

        // GET: ResidentPackage/Create
        public IActionResult Create()
        {
            ViewData["packageID"] = new SelectList(_context.Package, "packageID", "postalService");
            ViewData["residentID"] = new SelectList(_context.Resident, "residentID", "email");
            return View();
        }

        // POST: ResidentPackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("residentID,packageID")] ResidentPackage residentPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(residentPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["packageID"] = new SelectList(_context.Package, "packageID", "postalService", residentPackage.packageID);
            ViewData["residentID"] = new SelectList(_context.Resident, "residentID", "email", residentPackage.residentID);
            return View(residentPackage);
        }

        // GET: ResidentPackage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residentPackage = await _context.ResidentPackage.FindAsync(id);
            if (residentPackage == null)
            {
                return NotFound();
            }
            ViewData["packageID"] = new SelectList(_context.Package, "packageID", "postalService", residentPackage.packageID);
            ViewData["residentID"] = new SelectList(_context.Resident, "residentID", "email", residentPackage.residentID);
            return View(residentPackage);
        }

        // POST: ResidentPackage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("residentID,packageID")] ResidentPackage residentPackage)
        {
            if (id != residentPackage.residentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(residentPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidentPackageExists(residentPackage.residentID))
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
            ViewData["packageID"] = new SelectList(_context.Package, "packageID", "postalService", residentPackage.packageID);
            ViewData["residentID"] = new SelectList(_context.Resident, "residentID", "email", residentPackage.residentID);
            return View(residentPackage);
        }

        // GET: ResidentPackage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residentPackage = await _context.ResidentPackage
                .Include(r => r.Package)
                .Include(r => r.Resident)
                .FirstOrDefaultAsync(m => m.residentID == id);
            if (residentPackage == null)
            {
                return NotFound();
            }

            return View(residentPackage);
        }

        // POST: ResidentPackage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var residentPackage = await _context.ResidentPackage.FindAsync(id);
            if (residentPackage != null)
            {
                _context.ResidentPackage.Remove(residentPackage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResidentPackageExists(int id)
        {
            return _context.ResidentPackage.Any(e => e.residentID == id);
        }
    }
}
