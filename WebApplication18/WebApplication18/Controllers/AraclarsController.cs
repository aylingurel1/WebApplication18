using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    [Authorize]
    public class AraclarsController : Controller
    {
        private readonly OtoparkUygulamasiContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AraclarsController(OtoparkUygulamasiContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Araclars
        public async Task<IActionResult> Index()
        {
            var otoparkUygulamasiContext = _context.Araclar.Include(a => a.Kullanici);
            return View(await otoparkUygulamasiContext.ToListAsync());
        }

        // GET: Araclars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araclar = await _context.Araclar
                .Include(a => a.Kullanici)
                .FirstOrDefaultAsync(m => m.AracId == id);
            if (araclar == null)
            {
                return NotFound();
            }

            return View(araclar);
        }

        // GET: Araclars/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.Set<Kullanicilar>(), "KullaniciId", "KullaniciAdi");
            return View();
        }

        // POST: Araclars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AracId,KullaniciId,Plaka,Marka,Model,ImageFile,Renk")] Araclar araclar)
        {
            string wwwrootpath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(araclar.ImageFile.FileName);
            string extension = Path.GetExtension(araclar.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            araclar.Model = "~/Contents/" + fileName;
            string path = Path.Combine(wwwrootpath + "/Contents/", fileName);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await araclar.ImageFile.CopyToAsync(filestream);
            }
            _context.Add(araclar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["KullaniciId"] = new SelectList(_context.Set<Kullanicilar>(), "KullaniciId", "KullaniciId", araclar.KullaniciId);
            return View(araclar);
        }

        // GET: Araclars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araclar = await _context.Araclar.FindAsync(id);
            if (araclar == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.Set<Kullanicilar>(), "KullaniciId", "KullaniciId", araclar.KullaniciId);
            return View(araclar);
        }

        // POST: Araclars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AracId,KullaniciId,Plaka,Marka,Model,ImageFile,Renk")] Araclar araclar)
        {
            if (id != araclar.AracId)
            {
                return NotFound();
            }
            string wwwrootpath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(araclar.ImageFile.FileName);
            string extension = Path.GetExtension(araclar.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            araclar.Model = "~/Contents/" + fileName;
            string path = Path.Combine(wwwrootpath + "/Contents/", fileName);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await araclar.ImageFile.CopyToAsync(filestream);
            }

            try
                {
                    _context.Update(araclar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AraclarExists(araclar.AracId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["KullaniciId"] = new SelectList(_context.Set<Kullanicilar>(), "KullaniciId", "KullaniciId", araclar.KullaniciId);
            return View(araclar);
        }

        // GET: Araclars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araclar = await _context.Araclar
                .Include(a => a.Kullanici)
                .FirstOrDefaultAsync(m => m.AracId == id);
            if (araclar == null)
            {
                return NotFound();
            }

            return View(araclar);
        }

        // POST: Araclars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var araclar = await _context.Araclar.FindAsync(id);
            if (araclar != null)
            {
                _context.Araclar.Remove(araclar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AraclarExists(int id)
        {
            return _context.Araclar.Any(e => e.AracId == id);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Startp");
        }
    }
}
