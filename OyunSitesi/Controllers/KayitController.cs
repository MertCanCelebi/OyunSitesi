using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;

namespace OyunSitesi.Controllers
{
    public class KayitController : Controller
    {
        public IActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Kayit(KayitViewModel kayit)
        {
            if (ModelState.IsValid)
            {


            }
            return View(kayit);
        }
    }
}
