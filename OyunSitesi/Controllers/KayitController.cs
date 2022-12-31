using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;

namespace OyunSitesi.Controllers
{
    public class KayitController : Controller
    {
        private readonly DataBaseContext veritabaniBaglanti;

        public KayitController(DataBaseContext veritabaniBaglanti1)
        {
            veritabaniBaglanti = veritabaniBaglanti1;

        }
        public IActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Kayit(KayitViewModel kayit)
        {
            if (ModelState.IsValid)
            {
                if (veritabaniBaglanti.Kullanicilar.Any(x => x.KullaniciAdi.ToLower() == kayit.KullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(kayit.KullaniciAdi), "Bu kullanıcı adı sistemde kayıtlı.");
                    return View(kayit);
                }
                Kullanici kullanici = new()
                {
                    KullaniciAdi = kayit.KullaniciAdi,
                    Sifre = kayit.Sifre
                };
                veritabaniBaglanti.Kullanicilar.Add(kullanici);
                int affectedRowCount = veritabaniBaglanti.SaveChanges();
                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "Kullanıcı eklerken bir hata oluştu.");
                    return View(kayit);
                }
                else
                {
                    return RedirectToAction("Giris","Giris");
                }
            }

            return View(kayit);

        }
         
    }
}
