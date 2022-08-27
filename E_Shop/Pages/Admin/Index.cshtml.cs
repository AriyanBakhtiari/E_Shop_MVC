using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Data;
using E_Shop.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private EShopContext _context;
        public IndexModel(EShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _context.Products
                .Include(p => p.Item);
        }
        public void OnPost()
        {
        }

    }
}
