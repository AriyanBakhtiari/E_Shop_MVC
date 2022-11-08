using E_Shop.Data;
using E_Shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                .Include(i => i.Item)
                .ToList();
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
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

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemId);
            if (product != null)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
                if (order != null)
                {
                    var orderdetail = _context.OrderDetails
                         .FirstOrDefault(o => o.OrderId == order.OrderId && o.ProductId == product.Id);
                    if (orderdetail != null)
                    {
                        orderdetail.Count += 1;
                    }
                    else
                    {
                        _context.OrderDetails.Add(new OrderDetail
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Item.Price,
                            Count = 1,
                        });
                    }
                }

                else
                {

                    order = new Orders()
                    {
                        UserId = userId,
                        CreateDate = DateTime.Now,
                        IsFinaly = false
                    };

                    _context.Orders.Add(order);

                    _context.SaveChanges();

                    _context.OrderDetails.Add(new OrderDetail
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1,
                    });

                }
                _context.SaveChanges();

            }
            return RedirectToAction("CartView");
        }
        [Authorize]
        public IActionResult CartView()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.Where(o => o.UserId == userId && !o.IsFinaly)
                .Include(o => o.OrderDatail)
                .ThenInclude(o => o.Product).FirstOrDefault();

            return View(order);
        }
        [Authorize]
        public IActionResult FinalizePurchase()
        {
            var user = _context.Users.SingleOrDefault(o=> o.Email == User.Identity.Name);
            var order = _context.Orders.Where(o => o.UserId == user.UserId && !o.IsFinaly)
                .Include(o => o.OrderDatail)
                .ThenInclude(o => o.Product).FirstOrDefault();
            var TotalPrice = order.OrderDatail.Sum(s => s.Count * s.Price);
            if(user.Wallet < (double)TotalPrice) {
                ViewBag.Message = 1;
                return View();
            }
            order.IsFinaly = true;
            _context.SaveChanges();
            user.Wallet = user.Wallet - (double)TotalPrice;
            _context.SaveChanges();
            ViewBag.Message = 2 ;
            return View();
        }
        [Authorize]
        public IActionResult DeleteCart(int OrderDetailId)
        {
            var orderdetail = _context.OrderDetails.Find(OrderDetailId);
            if(orderdetail.Count == 1 )
            {
                _context.OrderDetails.Remove(orderdetail);
            }
            else
            {
                orderdetail.Count -= 1;
            }
            
            _context.SaveChanges();
            return RedirectToAction("CartView");
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
