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
    public class RezervasyonlarsController : Controller
    {
        private readonly OtoparkUygulamasiContext _context;

        public RezervasyonlarsController(OtoparkUygulamasiContext context)
        {
            _context = context;
        }

        // GET: Rezervasyonlars
        public async Task<IActionResult> Index()
        {
            var otoparkUygulamasiContext = _context.Rezervasyonlar.Include(r => r.Kullanici).Include(r => r.ParkYeri);
            return View(await otoparkUygulamasiContext.ToListAsync());
        }

        // GET: Rezervasyonlars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyonlar = await _context.Rezervasyonlar
                .Include(r => r.Kullanici)
                .Include(r => r.ParkYeri)
                .FirstOrDefaultAsync(m => m.RezervasyonId == id);
            if (rezervasyonlar == null)
            {
                return NotFound();
            }

            return View(rezervasyonlar);
        }

        // GET: Rezervasyonlars/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId");
            ViewData["ParkYeriId"] = new SelectList(_context.ParkYerleri, "ParkYeriId", "ParkYeriId");
            return View();
        }

        // POST: Rezervasyonlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervasyonId,KullaniciId,ParkYeriId,BaslangicZamani,BitisZamani,Durum")] Rezervasyonlar rezervasyonlar)
        {
            
                _context.Add(rezervasyonlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId", rezervasyonlar.KullaniciId);
            ViewData["ParkYeriId"] = new SelectList(_context.ParkYerleri, "ParkYeriId", "ParkYeriId", rezervasyonlar.ParkYeriId);
            return View(rezervasyonlar);
        }

        // GET: Rezervasyonlars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyonlar = await _context.Rezervasyonlar.FindAsync(id);
            if (rezervasyonlar == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId", rezervasyonlar.KullaniciId);
            ViewData["ParkYeriId"] = new SelectList(_context.ParkYerleri, "ParkYeriId", "ParkYeriId", rezervasyonlar.ParkYeriId);
            return View(rezervasyonlar);
        }

        // POST: Rezervasyonlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezervasyonId,KullaniciId,ParkYeriId,BaslangicZamani,BitisZamani,Durum")] Rezervasyonlar rezervasyonlar)
        {
            if (id != rezervasyonlar.RezervasyonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervasyonlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervasyonlarExists(rezervasyonlar.RezervasyonId))
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
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciId", rezervasyonlar.KullaniciId);
            ViewData["ParkYeriId"] = new SelectList(_context.ParkYerleri, "ParkYeriId", "ParkYeriId", rezervasyonlar.ParkYeriId);
            return View(rezervasyonlar);
        }

        // GET: Rezervasyonlars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyonlar = await _context.Rezervasyonlar
                .Include(r => r.Kullanici)
                .Include(r => r.ParkYeri)
                .FirstOrDefaultAsync(m => m.RezervasyonId == id);
            if (rezervasyonlar == null)
            {
                return NotFound();
            }

            return View(rezervasyonlar);
        }

        // POST: Rezervasyonlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervasyonlar = await _context.Rezervasyonlar.FindAsync(id);
            if (rezervasyonlar != null)
            {
                _context.Rezervasyonlar.Remove(rezervasyonlar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervasyonlarExists(int id)
        {
            return _context.Rezervasyonlar.Any(e => e.RezervasyonId == id);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Startp");
        }
    }
}
