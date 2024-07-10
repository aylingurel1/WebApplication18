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
    public class FiyatlandirmasController : Controller
    {
        private readonly OtoparkUygulamasiContext _context;

        public FiyatlandirmasController(OtoparkUygulamasiContext context)
        {
            _context = context;
        }

        // GET: Fiyatlandirmas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fiyatlandirma.ToListAsync());
        }

        // GET: Fiyatlandirmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiyatlandirma = await _context.Fiyatlandirma
                .FirstOrDefaultAsync(m => m.FiyatlandirmaId == id);
            if (fiyatlandirma == null)
            {
                return NotFound();
            }

            return View(fiyatlandirma);
        }

        // GET: Fiyatlandirmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fiyatlandirmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiyatlandirmaId,ParkYeriTipi,SaatlikFiyat,GünlükFiyat,AylıkFiyat")] Fiyatlandirma fiyatlandirma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fiyatlandirma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fiyatlandirma);
        }

        // GET: Fiyatlandirmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiyatlandirma = await _context.Fiyatlandirma.FindAsync(id);
            if (fiyatlandirma == null)
            {
                return NotFound();
            }
            return View(fiyatlandirma);
        }

        // POST: Fiyatlandirmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FiyatlandirmaId,ParkYeriTipi,SaatlikFiyat,GünlükFiyat,AylıkFiyat")] Fiyatlandirma fiyatlandirma)
        {
            if (id != fiyatlandirma.FiyatlandirmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fiyatlandirma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiyatlandirmaExists(fiyatlandirma.FiyatlandirmaId))
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
            return View(fiyatlandirma);
        }

        // GET: Fiyatlandirmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fiyatlandirma = await _context.Fiyatlandirma
                .FirstOrDefaultAsync(m => m.FiyatlandirmaId == id);
            if (fiyatlandirma == null)
            {
                return NotFound();
            }

            return View(fiyatlandirma);
        }

        // POST: Fiyatlandirmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fiyatlandirma = await _context.Fiyatlandirma.FindAsync(id);
            if (fiyatlandirma != null)
            {
                _context.Fiyatlandirma.Remove(fiyatlandirma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiyatlandirmaExists(int id)
        {
            return _context.Fiyatlandirma.Any(e => e.FiyatlandirmaId == id);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Startp");
        }
    }
}
