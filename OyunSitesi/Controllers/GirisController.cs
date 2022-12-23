using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;
using System.Security.Claims;

namespace OyunSitesi.Controllers
{
    public class GirisController : Controller
    {
        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Giris(GirisViewModel giris)
        {
            if (ModelState.IsValid)
            {


            }

            return View(giris);
        }
    }
}
