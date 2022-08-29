using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Models;
using E_Shop.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace E_Shop.Pages.Admin
{
    public class AddModel : PageModel
    {
        private EShopContext _context;
        public AddModel(EShopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public EditAddProductViewModel Product { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            };
            var item = new Item
            {
                Price = Product.Price,
                QuantityInStock = Product.QuantityInStock,
            };
            _context.Items.Add(item);
            _context.SaveChanges();
            var pro = new Product
            {
                Name = Product.Name,
                Description = Product.Description,
                Item = item,
            };
            _context.Products.Add(pro);
            _context.SaveChanges();
            pro.ItemId = pro.Id;
            _context.SaveChanges();

            if (Product.Image?.Length > 0)
            {
                string Location = Path.Combine(Directory.GetCurrentDirectory(), 
                    "wwwroot"
                    , "Images"
                    , pro.Id + Path.GetExtension(Product.Image.FileName));
                using (var stream = new FileStream(Location,FileMode.Create))
                {
                    Product.Image.CopyTo(stream);
                }
            }



            return RedirectToPage("index");
        }
    }
}
