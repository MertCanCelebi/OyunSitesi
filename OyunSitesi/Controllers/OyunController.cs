using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;
using OyunSitesi.VeriTabani;

namespace OyunSitesi.Controllers
{
    public class OyunController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataBaseContext veritabaniBaglanti;
        private readonly IMapper _mapper;

        public OyunController(DataBaseContext veritabaniBaglanti1, IMapper mapper, ILogger<HomeController> logger)
        {

            veritabaniBaglanti = veritabaniBaglanti1;
            _mapper = mapper;
            _logger = logger;
        }
        public IActionResult Index(int id)
        {
            List<OyunModel> oyunlar =
               veritabaniBaglanti.Oyunlar.ToList()
                   .Select(x => _mapper.Map<OyunModel>(x)).ToList();

            return View(oyunlar);

        }
        public IActionResult KategoriListesi(int id)
        {
            Kategori kategori = veritabaniBaglanti.Kategoriler.Find(id);
            KategoriModel model = _mapper.Map<KategoriModel>(kategori);

            return View(model);
        }
        public IActionResult YorumListesi(int id)
        {
            Yorum yorum = veritabaniBaglanti.Yorumlar.Find(id);
            YorumModel model = _mapper.Map<YorumModel>(yorum);

            return View(model);
        }
        public IActionResult YorumEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YorumEkle(YorumEkleModel model)
        {
            if (ModelState.IsValid)
            {
              

                Yorum yorum = _mapper.Map<Yorum>(model);

                veritabaniBaglanti.Yorumlar.Add(yorum);
                veritabaniBaglanti.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
