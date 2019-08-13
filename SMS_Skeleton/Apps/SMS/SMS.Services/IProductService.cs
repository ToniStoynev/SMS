using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services
{
    public interface IProductService
    {
        string CreateProduct(string name, decimal price);

        Product GetProductById(string id);

        IQueryable<Product> GetlAllProducts();
    }
}
