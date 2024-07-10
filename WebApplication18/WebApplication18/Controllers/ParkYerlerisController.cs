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
    public class ParkYerlerisController : Controller
    {
        private readonly OtoparkUygulamasiContext _context;

        public ParkYerlerisController(OtoparkUygulamasiContext context)
        {
            _context = context;
        }

        // GET: ParkYerleris
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkYerleri.ToListAsync());
        }

        // GET: ParkYerleris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkYerleri = await _context.ParkYerleri
                .FirstOrDefaultAsync(m => m.ParkYeriId == id);
            if (parkYerleri == null)
            {
                return NotFound();
            }

            return View(parkYerleri);
        }

        // GET: ParkYerleris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkYerleris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkYeriId,ParkYeriNumarasi,DolulukDurumu,Konum,Tip")] ParkYerleri parkYerleri)
        {
            
                _context.Add(parkYerleri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(parkYerleri);
        }

        // GET: ParkYerleris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkYerleri = await _context.ParkYerleri.FindAsync(id);
            if (parkYerleri == null)
            {
                return NotFound();
            }
            return View(parkYerleri);
        }

        // POST: ParkYerleris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkYeriId,ParkYeriNumarasi,DolulukDurumu,Konum,Tip")] ParkYerleri parkYerleri)
        {
            if (id != parkYerleri.ParkYeriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkYerleri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkYerleriExists(parkYerleri.ParkYeriId))
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
            return View(parkYerleri);
        }

        // GET: ParkYerleris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkYerleri = await _context.ParkYerleri
                .FirstOrDefaultAsync(m => m.ParkYeriId == id);
            if (parkYerleri == null)
            {
                return NotFound();
            }

            return View(parkYerleri);
        }

        // POST: ParkYerleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkYerleri = await _context.ParkYerleri.FindAsync(id);
            if (parkYerleri != null)
            {
                _context.ParkYerleri.Remove(parkYerleri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkYerleriExists(int id)
        {
            return _context.ParkYerleri.Any(e => e.ParkYeriId == id);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Startp");
        }
    }
}
