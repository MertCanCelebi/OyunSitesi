using Microsoft.AspNetCore.Mvc;

namespace OyunSitesi.Controllers
{
    public class YetkiController : Controller
    {
        public IActionResult Yetki()
        {
            return View();
        }
    }
}
