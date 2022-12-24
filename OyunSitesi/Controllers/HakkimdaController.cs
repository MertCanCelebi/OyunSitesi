using Microsoft.AspNetCore.Mvc;

namespace OyunSitesi.Controllers
{
    public class HakkimdaController : Controller
    {
        public IActionResult Hakkimda()
        {
            return View();
        }
    }
}
