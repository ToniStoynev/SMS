using SMS.Data;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly SMSContext db;

        public ProductService(SMSContext db)
        {
            this.db = db;
        }
        public string CreateProduct(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };
            this.db.Products.Add(product);
            this.db.SaveChanges();

            return product.Id;
        }

        public IQueryable<Product> GetlAllProducts()
        {
            return this.db.Products;
        }

        public Product GetProductById(string id)
        {
            var product = this.db.Products
                  .SingleOrDefault(x => x.Id == id);

            return product;
        }
    }
}
