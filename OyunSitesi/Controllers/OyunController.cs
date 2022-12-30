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
        public IActionResult Index()
        {
            List<OyunModel> oyunlar =
              veritabaniBaglanti.Oyunlar.ToList()
                  .Select(x => _mapper.Map<OyunModel>(x)).ToList();

            return View(oyunlar);
        }
    }
}
