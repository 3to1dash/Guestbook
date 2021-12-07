using DataAccess.Data;
using DataAccess.Models;
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
        public IActionResult Register(string returnUrl = "/")
        {
            return View(new RegisterModel { ReturnUrl = returnUrl });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel input)
        {
            var user = _userData.GetUser(input.Email).Result;
            if (user == null) return Unauthorized();
            if (!PasswordHelpers.Verify(input.Password, user.PasswordHash))
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel input)
        {
            var hashedPass = PasswordHelpers.Hash(input.Password);
            var user = new UserModel
            { 
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PasswordHash = hashedPass
            };

            var success = await _userData.InsertUser(user);
            if (success != 0)
                return LocalRedirect("/Account/Login");

            return LocalRedirect("/Account/Register");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}
