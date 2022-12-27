using Microsoft.AspNetCore.Mvc;

namespace OyunSitesi.Controllers
{
    public class IletisimController : Controller
    {
        public IActionResult Iletisim()
        {
            return View();
        }
        public IActionResult IletisimBilgileri()
        {
            return View();
        }

    }
}
