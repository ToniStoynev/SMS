using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Products = new HashSet<Product>();
        }
        public string Id { get; set; }
        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
