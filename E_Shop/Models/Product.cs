using System.Collections.Generic;

namespace E_Shop.Models
{
    public class Product
    {
        public  Product()
        {
            Categories = new List<Category>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Category> Categories { get; set; }
    }
}
