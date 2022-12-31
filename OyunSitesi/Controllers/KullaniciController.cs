using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;

namespace OyunSitesi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly DataBaseContext veritabaniBaglanti;
        private readonly IMapper _mapper;

        public KullaniciController(DataBaseContext veritabaniBaglanti1, IMapper mapper)
        {
            veritabaniBaglanti = veritabaniBaglanti1;
            _mapper = mapper;

        }
        public IActionResult Listele()
        {
            List<KullaniciModel> kullanicilar =
               veritabaniBaglanti.Kullanicilar.ToList()
                   .Select(x => _mapper.Map<KullaniciModel>(x)).ToList();

            return View(kullanicilar);
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(KullaniciEkleModel model)
        {
            if (ModelState.IsValid)
            {
                if (veritabaniBaglanti.Kullanicilar.Any(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.KullaniciAdi), "Zaten Kayıtlı.");
                    return View(model);
                }

                Kullanici user = _mapper.Map<Kullanici>(model);

                veritabaniBaglanti.Kullanicilar.Add(user);
                veritabaniBaglanti.SaveChanges();

                return RedirectToAction(nameof(Listele));
            }

            return View(model);
        }
        public IActionResult Duzenle(int id)
        {
            Kullanici kullanici = veritabaniBaglanti.Kullanicilar.Find(id);
            KullaniciDuzenleModel model = _mapper.Map<KullaniciDuzenleModel>(kullanici);

            return View(model);
        }

        [HttpPost]
        public IActionResult Duzenle(int id,KullaniciDuzenleModel model)
        {
            if (ModelState.IsValid)
            {
                if (veritabaniBaglanti.Kullanicilar.Any(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.KullaniciAdi), "Zaten Kayıtlı.");
                    return View(model);
                }

                Kullanici user = veritabaniBaglanti.Kullanicilar.Find(id);

                _mapper.Map(model, user);
                veritabaniBaglanti.SaveChanges();

                return RedirectToAction(nameof(Listele));
            }

            return View(model);
        }
        public IActionResult Sil(int id)
        {
            if (ModelState.IsValid)
            {

                Kullanici user = veritabaniBaglanti.Kullanicilar.Find(id);

                if (user != null)
                {
                    veritabaniBaglanti.Kullanicilar.Remove(user);
                    veritabaniBaglanti.SaveChanges();
                }

                return RedirectToAction(nameof(Listele));
            }

            return RedirectToAction(nameof(Listele));
        }
    }
}
