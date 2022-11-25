using Microsoft.AspNetCore.Mvc;
using E_Shop.Data;
using System.Threading.Tasks;
using System.Linq;
using E_Shop.Models;
using E_Shop.Repository;

namespace E_Shop.Components
{
    public class CategoryListComponent : ViewComponent
    {
        private IGroupRepository _groupRepository;

        public CategoryListComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View("/Views/Component/CategoryListComponentView.cshtml", _groupRepository.ShowCategoryView());
        }
    }
}
