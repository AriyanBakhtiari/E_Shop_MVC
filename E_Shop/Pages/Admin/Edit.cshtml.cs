using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Models;
using E_Shop.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;

namespace E_Shop.Pages.Admin
{
    public class EditModel : PageModel
    {
        private EShopContext _context;
        public EditModel(EShopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public EditAddProductViewModel Product { get; set; }
        
        
        
        public void OnGet(int id)
        {
            Product = _context.Products
                .Include(q => q.Item)
                .Where(q => q.Id == id)
                .Select(s => new EditAddProductViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Item.Price,
                    QuantityInStock = s.Item.QuantityInStock,
                    Description = s.Description
                })
                .FirstOrDefault();
                
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            };

            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(q=>q.Id == product.ItemId);

            product.Name = Product.Name;
            product.Description = Product.Description;
            item.Price = Product.Price;
            item.QuantityInStock = Product.QuantityInStock;
            _context.SaveChanges();

            if (Product.Image?.Length > 0)
            {
                string Location = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot"
                    , "Images"
                    , product.Id + Path.GetExtension(Product.Image.FileName));
                using (var stream = new FileStream(Location, FileMode.Create))
                {
                    Product.Image.CopyTo(stream);
                }
            }
            return RedirectToPage("Index");
        }
    }
}
