using System.Collections.Generic;
using System.Linq;

namespace E_Shop.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public int OrderId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public void addItem(CartItem Item)
        {
            if (CartItems.Exists(i => i.Item.Id == Item.Item.Id))
            {
                CartItems.Find(i => i.Item.Id == Item.Item.Id)
                    .Quantity += 1;
            }
            else
            {
                CartItems.Add(Item);
            }
            
        }

        public void removeItem(int ItemId)
        {
            var item = CartItems.SingleOrDefault(i => i.Item.Id == ItemId);
            if (item?.Quantity <= 1)
            {
                CartItems.Remove(item);
            }
            else if(item != null)
            {
                item.Quantity -= 1;
            }
        }
    }
}
