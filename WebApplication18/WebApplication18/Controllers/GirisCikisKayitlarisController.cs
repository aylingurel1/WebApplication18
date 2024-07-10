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
    public class GirisCikisKayitlarisController : Controller
    {
        private readonly OtoparkUygulamasiContext _context;

        public GirisCikisKayitlarisController(OtoparkUygulamasiContext context)
        {
            _context = context;
        }

        // GET: GirisCikisKayitlaris
        public async Task<IActionResult> Index()
        {
            var otoparkUygulamasiContext = _context.GirisCikisKayitlari.Include(g => g.Arac).Include(g => g.ParkYeri);
            return View(await otoparkUygulamasiContext.ToListAsync());
        }

        // GET: GirisCikisKayitlaris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var girisCikisKayitlari = await _context.GirisCikisKayitlari
                .Include(g => g.Arac)
                .Include(g => g.ParkYeri)
                .FirstOrDefaultAsync(m => m.KayitId == id);
            if (girisCikisKayitlari == null)
            {
                return NotFound();
            }

            return View(girisCikisKayitlari);
        }

        // GET: GirisCikisKayitlaris/Create
        public IActionResult Create()
        {
            ViewData["AracId"] = new SelectList(_context.Araclar, "AracId", "AracId");
            ViewData["ParkYeriId"] = new SelectList(_context.ParkYerleri, "ParkYeriId", "ParkYeriId");
            return View();
        }

        // POST: GirisCikisKayitlaris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KayitId,ParkYeriId,AracId,GirisZamani,CikisZamani")] GirisCikisKayitlari girisCikisKayitlari)
        {
            
            
                _context.Add(girisCikisKayitlari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["AracId"] = new SelectList(_context.Araclar, "AracId", "AracId", girisCikisKayitlari.AracId);
            ViewData["ParkYeriId"] = new SelectList(_context.ParkYerleri, "ParkYeriId", "ParkYeriId", girisCikisKayitlari.ParkYeriId);
            return View(girisCikisKayitlari);
        }

        // GET: GirisCikisKayitlaris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var girisCikisKayitlari = await _context.GirisCikisKayitlari.FindAsync(id);
            if (girisCikisKayitlari == null)
            {
                return NotFound();
            }
            ViewData["AracId"] = new SelectList(_context.Araclar, "AracId", "AracId", girisCikisKayitlari.AracId);
            ViewData["ParkYeriId"] = new SelectList(_context.ParkYerleri, "ParkYeriId", "ParkYeriId", girisCikisKayitlari.ParkYeriId);
            return View(girisCikisKayitlari);
        }

        // POST: GirisCikisKayitlaris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KayitId,ParkYeriId,AracId,GirisZamani,CikisZamani")] GirisCikisKayitlari girisCikisKayitlari)
        {
            if (id != girisCikisKayitlari.KayitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(girisCikisKayitlari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GirisCikisKayitlariExists(girisCikisKayitlari.KayitId))
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
            ViewData["AracId"] = new SelectList(_context.Araclar, "AracId", "AracId", girisCikisKayitlari.AracId);
            ViewData["ParkYeriId"] = new SelectList(_context.ParkYerleri, "ParkYeriId", "ParkYeriId", girisCikisKayitlari.ParkYeriId);
            return View(girisCikisKayitlari);
        }

        // GET: GirisCikisKayitlaris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var girisCikisKayitlari = await _context.GirisCikisKayitlari
                .Include(g => g.Arac)
                .Include(g => g.ParkYeri)
                .FirstOrDefaultAsync(m => m.KayitId == id);
            if (girisCikisKayitlari == null)
            {
                return NotFound();
            }

            return View(girisCikisKayitlari);
        }

        // POST: GirisCikisKayitlaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var girisCikisKayitlari = await _context.GirisCikisKayitlari.FindAsync(id);
            if (girisCikisKayitlari != null)
            {
                _context.GirisCikisKayitlari.Remove(girisCikisKayitlari);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GirisCikisKayitlariExists(int id)
        {
            return _context.GirisCikisKayitlari.Any(e => e.KayitId == id);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Startp");
        }
    }
}
