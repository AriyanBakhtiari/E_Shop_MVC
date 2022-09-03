using Microsoft.AspNetCore.Mvc;
using E_Shop.Models;
using E_Shop.Repository;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace E_Shop.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userrepository;
        public AccountController(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registermodel)
        {
            if (!ModelState.IsValid)
            {
                return View(registermodel);
            }
            if (_userrepository.IsEmailValids(registermodel.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا در سایت ثبت نام کرده است.");
                return View(registermodel);
            }
            Users user = new Users()
            {
                Email = registermodel.Email.ToLower(),
                Password = registermodel.Password,
                RegisterDate = DateTime.Now,
                IsAdmin = false
            };
            _userrepository.AddUser(user);
            return View("SuccessRegister", registermodel);

        }





        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = _userrepository.GetUser(loginViewModel.Email, loginViewModel.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email", "اطلاعات وارد شده اشتباه است ");
                return View(loginViewModel);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim("IsAdmin", user.IsAdmin.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var princial = new ClaimsPrincipal(identity);
            var propertise = new AuthenticationProperties
            {
                IsPersistent = loginViewModel.RememberMe
            };

            HttpContext.SignInAsync(princial, propertise);

            return Redirect("/");
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
