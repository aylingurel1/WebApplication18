using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication18.Models;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace WebApplication18.Controllers
{
    [Authorize]
    public class DemoController : Controller
    {
        private readonly OtoparkUygulamasiContext _context;
        Cascade cd = new Cascade();
        public DemoController(OtoparkUygulamasiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            List < Kullanicilar > kullanicilarlist = new List<Kullanicilar>();
            cd.KullanicilarList = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi");
            cd.AraclarList = new SelectList(_context.Araclar, "AracId", "Marka");
                
            return View(cd);
        }


        public JsonResult GetAraclar(int KullaniciId)
        {
            var kullanicilist = (from kullanici in _context.Araclar
                                 where kullanici.KullaniciId == KullaniciId
                                 select new
                                 {
                                     Text = kullanici.Marka,
                                     Value = kullanici.AracId
                                 }).ToList();
            return Json(kullanicilist, new System.Text.Json.JsonSerializerOptions());
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Startp");
        }
    }
}
