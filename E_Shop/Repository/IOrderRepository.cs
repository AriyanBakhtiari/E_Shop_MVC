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
            if (user == null) return 0;
            
            var UserOrder = _context.Orders.Include(i => i.OrderDatail)
                .SingleOrDefault(i => i.UserId == user.UserId && i.IsFinaly == false);
                
            if (UserOrder == null) return 0;
                
            return UserOrder.OrderDatail.Sum(order => order.Count);

        }
    }
}
