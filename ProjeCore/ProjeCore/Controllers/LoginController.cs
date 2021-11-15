using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;

namespace ProjeCore.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View(); 
        }
        public async Task<IActionResult> GirisYap(Admin a)
        {
            var deger = c.Admins.FirstOrDefault(item=>item.Kullanıcı == a.Kullanıcı && item.Sifre == a.Sifre);
            if (deger != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, a.Kullanıcı)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal Principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(Principal);
                return RedirectToAction("Index", "Personelim"); 
            }
            return View();
        }
        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap", "LogIn");
        }
    }
}
