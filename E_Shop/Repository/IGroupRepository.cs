using E_Shop.Data;
using E_Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace E_Shop.Repository
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategory();
        IEnumerable<ShowGroupViewModel> ShowCategoryView();

    }

    public class GroupRepository : IGroupRepository
    {
        private EShopContext _context;
        public GroupRepository(EShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategory()
        {
            return _context.Categories;
        }

        public IEnumerable<ShowGroupViewModel> ShowCategoryView()
        {
            return _context.Categories
                .Select(n => new ShowGroupViewModel
                {
                    GroupName = n.Name,
                    GroupId = n.Id,
                    ProductCount = _context.CategoryToProducts.Count(c => c.CategoryId == n.Id),
                }).ToList();
        }
    }
}
