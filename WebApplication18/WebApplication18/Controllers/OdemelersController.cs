using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    [Authorize]
    public class OdemelersController : Controller
    {
        private readonly OtoparkUygulamasiContext _context;

        public OdemelersController(OtoparkUygulamasiContext context)
        {
            _context = context;
        }

        // GET: Odemelers
        public async Task<IActionResult> Index()
        {
            var otoparkUygulamasiContext = _context.Odemeler.Include(o => o.Rezervasyon);
            return View(await otoparkUygulamasiContext.ToListAsync());
        }

        // GET: Odemelers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odemeler = await _context.Odemeler
                .Include(o => o.Rezervasyon)
                .FirstOrDefaultAsync(m => m.OdemeId == id);
            if (odemeler == null)
            {
                return NotFound();
            }

            return View(odemeler);
        }

        // GET: Odemelers/Create
        public IActionResult Create()
        {
            ViewData["RezervasyonId"] = new SelectList(_context.Set<Rezervasyonlar>(), "RezervasyonId", "RezervasyonId");
            return View();
        }

        // POST: Odemelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdemeId,RezervasyonId,Miktar,OdemeYontemi,OdemeTarihi")] Odemeler odemeler)
        {
            
                _context.Add(odemeler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["RezervasyonId"] = new SelectList(_context.Set<Rezervasyonlar>(), "RezervasyonId", "RezervasyonId", odemeler.RezervasyonId);
            return View(odemeler);
        }

        // GET: Odemelers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odemeler = await _context.Odemeler.FindAsync(id);
            if (odemeler == null)
            {
                return NotFound();
            }
            ViewData["RezervasyonId"] = new SelectList(_context.Set<Rezervasyonlar>(), "RezervasyonId", "RezervasyonId", odemeler.RezervasyonId);
            return View(odemeler);
        }

        // POST: Odemelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdemeId,RezervasyonId,Miktar,OdemeYontemi,OdemeTarihi")] Odemeler odemeler)
        {
            if (id != odemeler.OdemeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odemeler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdemelerExists(odemeler.OdemeId))
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
            ViewData["RezervasyonId"] = new SelectList(_context.Set<Rezervasyonlar>(), "RezervasyonId", "RezervasyonId", odemeler.RezervasyonId);
            return View(odemeler);
        }

        // GET: Odemelers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odemeler = await _context.Odemeler
                .Include(o => o.Rezervasyon)
                .FirstOrDefaultAsync(m => m.OdemeId == id);
            if (odemeler == null)
            {
                return NotFound();
            }

            return View(odemeler);
        }

        // POST: Odemelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odemeler = await _context.Odemeler.FindAsync(id);
            if (odemeler != null)
            {
                _context.Odemeler.Remove(odemeler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdemelerExists(int id)
        {
            return _context.Odemeler.Any(e => e.OdemeId == id);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Startp");
        }
    }
}
