using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;
using System.Data;
using System.Security.Claims;

namespace OyunSitesi.Controllers
{

    [Authorize(Roles = "kullanici,admin")]
    public class KategoriController : Controller
    {
        private readonly DataBaseContext veritabaniBaglanti;
        private readonly IMapper _mapper;

        public KategoriController(DataBaseContext veritabaniBaglanti1, IMapper mapper)
        {
            veritabaniBaglanti = veritabaniBaglanti1;
            _mapper = mapper;

        }
        public IActionResult Listele()
        {
            List<KategoriModel> kategoriler =
               veritabaniBaglanti.Kategoriler.ToList()
                   .Select(x => _mapper.Map<KategoriModel>(x)).ToList();

            return View(kategoriler);
        }
        public IActionResult KategoriOyun(int id)
        {
            List<OyunModel> Oyunlar =
              veritabaniBaglanti.Oyunlar.ToList()
              .Where(x => x.KategoriId == id)
                  .Select(x => _mapper.Map<OyunModel>(x)).ToList();
            return View(Oyunlar);
        }
    }
}
