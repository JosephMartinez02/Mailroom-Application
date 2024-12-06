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
    public class UnknownController : Controller
    {
        private readonly MvcPackageContext _context;

        public UnknownController(MvcPackageContext context)
        {
            _context = context;
        }

        // GET: Unknown
        public async Task<IActionResult> Index()
        {
            var mvcPackageContext = _context.Unknown.Include(u => u.Package);
            return View(await mvcPackageContext.ToListAsync());
        }

        // GET: Unknown/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unknown = await _context.Unknown
                .Include(u => u.Package)
                .FirstOrDefaultAsync(m => m.unknownID == id);
            if (unknown == null)
            {
                return NotFound();
            }

            return View(unknown);
        }

        // GET: Unknown/Create
        public IActionResult Create()
        {
            ViewData["packageID"] = new SelectList(_context.Package, "packageID", "packageID");
            return View();
        }

        // POST: Unknown/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("unknownID,packageID")] Unknown unknown)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unknown);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["packageID"] = new SelectList(_context.Package, "packageID", "postalService", unknown.packageID);
            return View(unknown);
        }

        // GET: Unknown/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unknown = await _context.Unknown.FindAsync(id);
            if (unknown == null)
            {
                return NotFound();
            }
            ViewData["packageID"] = new SelectList(_context.Package, "packageID", "postalService", unknown.packageID);
            return View(unknown);
        }

        // POST: Unknown/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("unknownID,packageID")] Unknown unknown)
        {
            if (id != unknown.unknownID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unknown);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnknownExists(unknown.unknownID))
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
            ViewData["packageID"] = new SelectList(_context.Package, "packageID", "postalService", unknown.packageID);
            return View(unknown);
        }

        // GET: Unknown/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unknown = await _context.Unknown
                .Include(u => u.Package)
                .FirstOrDefaultAsync(m => m.unknownID == id);
            if (unknown == null)
            {
                return NotFound();
            }

            return View(unknown);
        }

        // POST: Unknown/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unknown = await _context.Unknown.FindAsync(id);
            if (unknown != null)
            {
                _context.Unknown.Remove(unknown);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnknownExists(int id)
        {
            return _context.Unknown.Any(e => e.unknownID == id);
        }
    }
}
