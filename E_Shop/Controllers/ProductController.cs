using E_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly EShopContext _context;
        public ProductController(EShopContext context)
        {
            _context = context;
        }
        [Route("Category/{id}/{name}")]
        public IActionResult ProductCategory(int id , string name)
        {
            ViewData["CategoryName"] = name;
            var Producs = _context.CategoryToProducts
                .Where(c => c.CategoryId == id)
                .Include(c => c.Product)
                .Include(i => i.Product.Item)
                .Select(c => c.Product)
                .ToList();

            return View(Producs);
        }
    }
}
