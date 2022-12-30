using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;
using OyunSitesi.VeriTabani;
using System.Diagnostics;

namespace OyunSitesi.Controllers
{
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

            var query = (from k in veritabaniBaglanti.Oyunlar
                         where oyun.Id == k.Id
                         select new Oyun() { Id = k.Id, OyunAd = k.OyunAd, Icerik = k.Icerik,Resim=k.Resim,KategoriId=k.KategoriId,Yorum=k.Yorum }).ToList();
         
            ViewBag.oyun = oyun;
            return View(new Oyun());
        }
        public IActionResult Index()
        {
            List<OyunModel> kategoriler =
               veritabaniBaglanti.Oyunlar.ToList()
                   .Select(x => _mapper.Map<OyunModel>(x)).ToList();

            return View(kategoriler);
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}