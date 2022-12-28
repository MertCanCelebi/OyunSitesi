using Microsoft.AspNetCore.Mvc;

namespace OyunSitesi.Controllers
{
    public class OyunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
