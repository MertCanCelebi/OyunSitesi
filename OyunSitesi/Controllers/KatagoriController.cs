using Microsoft.AspNetCore.Mvc;

namespace OyunSitesi.Controllers
{
    public class Katagori : Controller
    {
        public IActionResult kategori()
        {
            return View();
        }
    }
}
