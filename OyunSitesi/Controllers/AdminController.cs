using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;

namespace OyunSitesi.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {

        private readonly DataBaseContext veritabaniBaglanti;
        private readonly IMapper _mapper;

        public AdminController(DataBaseContext veritabaniBaglanti1, IMapper mapper)
        {
            veritabaniBaglanti = veritabaniBaglanti1;
            _mapper = mapper;

        }
        public IActionResult Listele()
        {
            List<OyunModel> oyunlar =
               veritabaniBaglanti.Oyunlar.ToList()
                   .Select(x => _mapper.Map<OyunModel>(x)).ToList();

            return View(oyunlar);
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(OyunEkleModel model)
        {
            if (ModelState.IsValid)
            {
                if (veritabaniBaglanti.Oyunlar.Any(x => x.Id == model.Id))
                {
                    ModelState.AddModelError(nameof(model.Id), "Zaten Kayıtlı.");
                    return View(model);
                }

                Oyun oyun = _mapper.Map<Oyun>(model);

                veritabaniBaglanti.Oyunlar.Add(oyun);
                veritabaniBaglanti.SaveChanges();

                return RedirectToAction(nameof(Listele));
            }

            return View(model);
        }
        public IActionResult Duzenle(int id)
        {
            Oyun oyun = veritabaniBaglanti.Oyunlar.Find(id);
            OyunDuzenleModel model = _mapper.Map<OyunDuzenleModel>(oyun);

            return View(model);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, OyunDuzenleModel model)
        {
            if (ModelState.IsValid)
            {
               
                Oyun oyun = veritabaniBaglanti.Oyunlar.Find(id);

                _mapper.Map(model, oyun);
                veritabaniBaglanti.SaveChanges();

                return RedirectToAction(nameof(Listele));
            }

            
             return View(model);
        }
        public IActionResult Sil(int id)
        {
            if (ModelState.IsValid)
            {

                Oyun oyun = veritabaniBaglanti.Oyunlar.Find(id);

                if (oyun != null)
                {
                    veritabaniBaglanti.Oyunlar.Remove(oyun);
                    veritabaniBaglanti.SaveChanges();
                }

                return RedirectToAction(nameof(Listele));
            }

            return RedirectToAction(nameof(Listele));
        }
        public IActionResult YorumListele()
        {
            List<YorumModel> yorumlar =
               veritabaniBaglanti.Yorumlar.ToList()
                   .Select(x => _mapper.Map<YorumModel>(x)).ToList();

            return View(yorumlar);
        }
        public IActionResult YorumSil(int id)
        {
            if (ModelState.IsValid)
            {

                Yorum yorum = veritabaniBaglanti.Yorumlar.Find(id);

                if (yorum != null)
                {
                    veritabaniBaglanti.Yorumlar.Remove(yorum);
                    veritabaniBaglanti.SaveChanges();
                }

                return RedirectToAction(nameof(YorumListele));
            }

            return RedirectToAction(nameof(YorumListele));
        }
       
    }
}
