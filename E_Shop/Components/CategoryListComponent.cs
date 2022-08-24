using Microsoft.AspNetCore.Mvc;
using E_Shop.Data;
using System.Threading.Tasks;
using System.Linq;
using E_Shop.Models;

namespace E_Shop.Components
{
    public class CategoryListComponent : ViewComponent
    {
        private EShopContext _context;

        public CategoryListComponent(EShopContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var category = _context.Categories.Select(n => new ShowGroupViewModel
            {
                GroupName = n.Name,
                GroupId = n.Id,
                ProductCount = _context.CategoryToProducts.Count(c => c.CategoryId == n.Id),
            }).ToList();

            return View("/Views/Component/CategoryListComponentView.cshtml", category);
        }
    }
}
