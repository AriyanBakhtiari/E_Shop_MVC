using Microsoft.AspNetCore.Mvc;
using E_Shop.Models;

namespace E_Shop.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registermodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            return RedirectToAction("Register");
        }
        public IActionResult Login()
        {
            return null;
        }
    } 
}
