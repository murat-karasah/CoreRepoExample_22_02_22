
using CoreRepoExample_22_02_22.Controllers.Repository;
using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private ILoginRepository lrep;
        public LoginController(ILoginRepository _lrep)
        {
            lrep = _lrep;
        }
        public IActionResult Index()
        {
            return View();
        }

      
        //public IActionResult SingIn()
        //{
        //    return View();
        //}

        public async Task<IActionResult> SingIn(string username, string pass)
        {
            Admin a = lrep.GetAdmin(username, pass);
            if (a!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,a.username)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SingIn");
        }
    }
}
