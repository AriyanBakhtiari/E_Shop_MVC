using Microsoft.AspNetCore.Mvc;
using E_Shop.Data;
using System.Threading.Tasks;

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
            var category = _context.Categories;

            return View("/Views/Component/CategoryListComponentView.cshtml", _context.Categories);
        }
    }
}
