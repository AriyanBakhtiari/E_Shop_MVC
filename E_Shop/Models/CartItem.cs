namespace E_Shop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal TotalProce()
        {
            return Item.Price * Quantity;
        }
    }
}
