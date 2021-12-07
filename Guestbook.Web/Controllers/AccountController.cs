using DataAccess.Data;
using Guestbook.Web.ControllersHelpers;
using Guestbook.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Guestbook.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserData _userData;

        public AccountController(IUserData userData)
        {
            _userData = userData;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel input)
        {
            var user = _userData.GetUser(input.Email).Result;
            if (user == null) return Unauthorized();
            var hashedPass = Convert.FromBase64String(user.PasswordHash);
            if (!PasswordHelpers.VerifyPassword(hashedPass, input.Password))
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = input.RememberLogin });

            return LocalRedirect(input.ReturnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}
