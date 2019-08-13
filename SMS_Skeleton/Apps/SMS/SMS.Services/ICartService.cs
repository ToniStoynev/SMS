using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services
{
    public interface ICartService
    {
        string CreateCart();

        IQueryable<Product> GetAllProducts();
        void AddProduct(Product product);

        void Buy();
    }
}
