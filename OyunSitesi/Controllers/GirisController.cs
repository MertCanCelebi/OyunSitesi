using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;
using System.Security.Claims;
using OyunSitesi.VeriTabani;

namespace OyunSitesi.Controllers
{
    public class GirisController : Controller
    {
        private readonly DataBaseContext veritabaniBaglanti;

        public GirisController(DataBaseContext veritabaniBaglanti1)
        {
            veritabaniBaglanti = veritabaniBaglanti1;

        }
        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Giris(GirisViewModel giris)
        {
            if (ModelState.IsValid)
            {

                Kullanici kullanici = veritabaniBaglanti.Kullanicilar.SingleOrDefault(x => x.KullaniciAdi.ToLower() == giris.KullaniciAdi.ToLower() && x.Sifre == giris.Sifre);

                if (kullanici != null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, kullanici.AdSoyad ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, kullanici.Rol));
                    claims.Add(new Claim("KullaniciAdi", giris.KullaniciAdi));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                }

            }

            return View(giris);
        }
    }
}
