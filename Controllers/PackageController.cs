using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MailroomApplication.Models;
using MvcPackage.Data;

namespace MailroomApplication.Controllers
{
    public class PackageController : Controller
    {
        private readonly MvcPackageContext _context;

        public PackageController(MvcPackageContext context)
        {
            _context = context;
        }

        // GET: Package
        public async Task<IActionResult> Index()
        {
            var mvcPackageContext = _context.Package.Include(p => p.Resident);
            return View(await mvcPackageContext.ToListAsync());
        }

        public async Task<IActionResult> Search(string searchString)
        {
            if (_context.Resident == null)
            {
                return Problem("Entity set 'MvcPackageContext.Resident' is null");
            }

            var residents = from r in _context.Resident
                            select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                residents = residents.Where(s => s.residentName!.ToUpper().Contains(searchString.ToUpper()));
            }
            return View(await residents.ToListAsync());
        }

        // GET: Package/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Package
                .Include(p => p.Resident)
                .FirstOrDefaultAsync(m => m.packageID == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // GET: Package/Create
        public IActionResult Create()
        {
            ViewData["residentID"] = new SelectList(_context.Resident, "residentID", "residentName");
            return View();
        }

        // POST: Package/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("packageID,postalService,checkInDate,checkOutDate,status,residentID")] Package package)
        {
            if (ModelState.IsValid)
            {
                _context.Add(package);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["residentID"] = new SelectList(_context.Resident, "residentID", "residentName", package.residentID);
            return View(package);
        }

        // GET: Package/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            ViewData["residentID"] = new SelectList(_context.Resident, "residentID", "residentName", package.residentID);
            return View(package);
        }

        // POST: Package/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("packageID,postalService,checkInDate,checkOutDate,status,residentID")] Package package)
        {
            if (id != package.packageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(package);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageExists(package.packageID))
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
            ViewData["residentID"] = new SelectList(_context.Resident, "residentID", "residentName", package.residentID);
            return View(package);
        }

        // GET: Package/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Package
                .Include(p => p.Resident)
                .FirstOrDefaultAsync(m => m.packageID == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // POST: Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var package = await _context.Package.FindAsync(id);
            if (package != null)
            {
                _context.Package.Remove(package);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageExists(int id)
        {
            return _context.Package.Any(e => e.packageID == id);
        }

        public async Task<IActionResult> SendEmail()
        {
            try
            {
                var residents = from r in _context.Resident
                            select r;

                string senderEmail = "noreply@buffteks.org";
                string password = "cidm4360fall2024@*";
                var toEmail = residents.Select(e => e.email).ToString()!;
                string subject = "Package Delivered!";
                // Create the email message
                MailMessage message = new MailMessage();
                message.From = new MailAddress(senderEmail); // Set the sender's email address
                message.To.Add(toEmail);                     // Add the recipient's email address

                message.Subject = subject;                   // Set the subject line of the email

                // Define the HTML content for the email body
                string htmlContent = @"
            <html>
                <body>
                    <p>Dear Resident,</p>
                    <p>We have received a package for you at the leasing office. Due to limited storage space, please pick up your package within <strong>5 days</strong>.</p>
                    <p>If the package is not picked up within this time frame, it will be returned to the post office.</p>
                    <p>Thank you!</p>
                    <p>BuffTeks Apartment Leasing Office</p>
                </body>
            </html>
            ";

                // AlternateView allows for specifying different versions of the email content (HTML in this case)
                message.AlternateViews.Add(new AlternateView(new MemoryStream(Encoding.UTF8.GetBytes(htmlContent)), "text/html"));

                // Configure the SMTP client to send the email
                SmtpClient smtpClient = new SmtpClient("mail.privateemail.com", 587); // Set SMTP server and port
                smtpClient.EnableSsl = true;                                          // Enable SSL encryption for security
                smtpClient.UseDefaultCredentials = false;                             // Disable default credentials
                smtpClient.Credentials = new NetworkCredential(senderEmail, password); // Use provided sender email and password for authentication

                // Send the email
                smtpClient.Send(message);
                Console.WriteLine("Email sent successfully!");
                return View(await residents.ToListAsync());
            }
            catch (Exception ex)
            {
                // Catch any exceptions that occur and display an error message
                Console.WriteLine($"Failed to send email: {ex.Message}");
                return NotFound();
            }
        }

        // // Example usage of the SendEmail method
        // public static void Main()
        // {
        //     // Replace 'REPLACE_WITH_RESIDENT_EMAIL' with the actual recipient's email address
        //     SendEmail(
        //         senderEmail: "noreply@buffteks.org",           // Sender's email address
        //         password: "cidm4360fall2024@*",                // Sender's email password
        //         toEmail: "jamartinez15@buffs.wtamu.edu",        // Recipient's email address
        //         subject: "Package Pickup Notification"         // Subject of the email
        //     );
        // }
    }


}
