using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IUserService _userService;

        //public AccountController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string login)
        {
            var user = new ContaUsuario { Login = login, Senha = "123" };
            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View();
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Login));
            //identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
            //identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));

            identity.AddClaim(new Claim("EmpresaPadrao", "1"));

            if (login == "dpcosta")
                identity.AddClaim(new Claim(ClaimTypes.Role, "Operador"));
            else
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

            //foreach (var role in user.Roles)
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, role.Role));
            //}

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
