using E_Shop.Data;
using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Controllers
{
    public class HomeController : Controller
    {
        private EShopContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, EShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var product = _context.Products
                .ToList();
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details(int id) {
            var products = _context.Products
                .Include(p => p.Item)
                .SingleOrDefault(p => p.Id == id);
            var category = _context.Products
                .Where(i => i.Id == id)
                .SelectMany(c => c.CategoryToProduct)
                .Select(ca => ca.Category)
                .ToList();
            var detailview = new DetailModelView()
            {
                Product = products,
                Categories = category
            };
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                return View(detailview);
            }


        }


        [Route("/ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
