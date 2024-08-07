﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class Kullanicilars1Controller : Controller
    {
        private readonly OtoparkUygulamasiContext _context;

        public Kullanicilars1Controller(OtoparkUygulamasiContext context)
        {
            _context = context;
        }

        // GET: Kullanicilars1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kullanicilar.ToListAsync());
        }

        // GET: Kullanicilars1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.KullaniciId == id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return View(kullanicilar);
        }

        // GET: Kullanicilars1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanicilars1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KullaniciId,KullaniciAdi,SifreHash,Eposta,Rol")] Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanicilar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanicilar);
        }

        // GET: Kullanicilars1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilar.FindAsync(id);
            if (kullanicilar == null)
            {
                return NotFound();
            }
            return View(kullanicilar);
        }

        // POST: Kullanicilars1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KullaniciId,KullaniciAdi,SifreHash,Eposta,Rol")] Kullanicilar kullanicilar)
        {
            if (id != kullanicilar.KullaniciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullanicilar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullanicilarExists(kullanicilar.KullaniciId))
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
            return View(kullanicilar);
        }

        // GET: Kullanicilars1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.KullaniciId == id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return View(kullanicilar);
        }

        // POST: Kullanicilars1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kullanicilar = await _context.Kullanicilar.FindAsync(id);
            if (kullanicilar != null)
            {
                _context.Kullanicilar.Remove(kullanicilar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullanicilarExists(int id)
        {
            return _context.Kullanicilar.Any(e => e.KullaniciId == id);
        }
    }
}
