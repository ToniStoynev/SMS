using SMS.Data;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly SMSContext db;
        private readonly IProductService productService;

        public CartService(SMSContext db, IProductService productService)
        {
            this.db = db;
            this.productService = productService;
        }

        public void AddProduct(Product product)
        {
            //this.User
        }

        public void Buy()
        {
            var products = this.GetAllProducts().ToList();
            this.db.Products.RemoveRange(products);
            this.db.SaveChanges();
        }

        public string CreateCart()
        {
            var cart = new Cart();
            this.db.Add(cart);

            this.db.SaveChanges();

            return cart.Id;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return this.db.Products;
        }
    }
}
