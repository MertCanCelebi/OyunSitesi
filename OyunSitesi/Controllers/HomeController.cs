using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace OyunSitesi.Controllers
{
    [Authorize(Roles = "kullanici,admin")]
    public class HomeController : Controller
    {

     
        private readonly ILogger<HomeController> _logger;
        private readonly DataBaseContext veritabaniBaglanti;
        private readonly IMapper _mapper;

        public HomeController(DataBaseContext veritabaniBaglanti1, IMapper mapper,ILogger<HomeController> logger)
        {

            veritabaniBaglanti = veritabaniBaglanti1;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
           
            Oyun oyun =veritabaniBaglanti.Oyunlar.FirstOrDefault(I => I.Id ==id);

           
            var query1 = (from k in veritabaniBaglanti.Yorumlar
                         where oyun.Id == k.OyunId
                         select new Yorum() { Id = k.Id, YorumIcerik = k.YorumIcerik, OyunId = k.OyunId, KullaniciId = k.KullaniciId }).ToList();



            int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Kullanici kullanici = veritabaniBaglanti.Kullanicilar.SingleOrDefault(x => x.Id == userid);

            ViewBag.kullanici = kullanici;
            ViewBag.oyun = oyun;
            ViewBag.yorumlar = query1;           
            return View(new Yorum());
        }
        [HttpPost]
        public IActionResult YorumEkle(Yorum yorum)
        {
            veritabaniBaglanti.Yorumlar.Add(yorum);
            veritabaniBaglanti.SaveChanges();
            return RedirectToAction("Detail", new { id = yorum.OyunId });

        }
        public IActionResult Index()
        {
            List<OyunModel> oyunlar =
               veritabaniBaglanti.Oyunlar.ToList()
                   .Select(x => _mapper.Map<OyunModel>(x)).ToList();
            return View(oyunlar);
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}