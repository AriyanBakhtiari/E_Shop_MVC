using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Shop.Data;
using E_Shop.Models;

namespace E_Shop.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly E_Shop.Data.EShopContext _context;

        public IndexModel(E_Shop.Data.EShopContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
