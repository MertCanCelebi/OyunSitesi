using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace OyunSitesi.Controllers
{
    public class ProfilController : Controller
    {
        private readonly DataBaseContext veritabaniBaglanti;

        public ProfilController(DataBaseContext veritabaniBaglanti1)
        {
            veritabaniBaglanti = veritabaniBaglanti1;

        }

        public IActionResult Profil()
        {
            ProfileBilgileri();
        
                return View();
        }
        private void ProfileBilgileri()
        {
            int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Kullanici kullanici = veritabaniBaglanti.Kullanicilar.SingleOrDefault(x => x.Id == userid);

            ViewData["AdSoyad"] = kullanici.AdSoyad;
        }
        [HttpPost]
        public IActionResult IsimDegisikligi([Required(ErrorMessage ="Boş olamaz.")][StringLength(50)] string? AdSoyad)
        {
            if (ModelState.IsValid)
            {
                int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanici kullanici = veritabaniBaglanti.Kullanicilar.SingleOrDefault(x => x.Id == userid);

                kullanici.AdSoyad = AdSoyad;
                veritabaniBaglanti.SaveChanges();

                ViewData["result"] = "AdDegisikligi";
            }

            ProfileBilgileri();
            return View("Profil");
        }

        [HttpPost]
        public IActionResult SifreDegisikligi([Required(ErrorMessage = "Boş olamaz.")][MaxLength(20)] string? Sifre)
        {
            if (ModelState.IsValid)
            {
                int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanici kullanici = veritabaniBaglanti.Kullanicilar.SingleOrDefault(x => x.Id == userid);
                kullanici.Sifre= Sifre;
                veritabaniBaglanti.SaveChanges();

                ViewData["result"] = "SifreDegisikligi";
            }

            ProfileBilgileri();
            return View("Profil");
        }

    }
}
