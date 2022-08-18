using System.Collections.Generic;

namespace E_Shop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CategoryToProduct> CategoryToProduct { get; set; }
    }
}
