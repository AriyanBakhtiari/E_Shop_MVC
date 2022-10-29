using E_Shop.Data;
using E_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace E_Shop.Repository
{
    public interface IOrderRepository
    {
         int OrderCount(string email);

    }
    public class OrderRepository : IOrderRepository
    {
        private EShopContext _context;
        public OrderRepository(EShopContext context )
        {
            _context = context;
            
        }

        public int OrderCount(string email)
        {
            var user = _context.Users.SingleOrDefault(e => e.Email == email);
            if (user != null)
            {
                var UserOrder = _context.Orders.Include(i => i.OrderDatail)
               .SingleOrDefault(i => i.UserId == user.UserId && i.IsFinaly == false);
                return UserOrder.OrderDatail.Count();
            }
            return 0;
           
        }
    }
}
