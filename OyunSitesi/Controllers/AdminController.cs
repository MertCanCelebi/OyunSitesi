using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OyunSitesi.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {

        public IActionResult Admin()
        {
            return View();
        }
    }
}
