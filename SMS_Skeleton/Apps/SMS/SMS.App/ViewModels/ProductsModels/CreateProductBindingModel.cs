using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.App.ViewModels.ProductsModels
{
    public class CreateProductBindingModel
    {
        [RequiredSis]
        [StringLengthSis(4, 20, "Name should be between 5 and 20 characters")]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(typeof(decimal), "0.05", "1000", "price should be between 0.05 and 1000")]
        public decimal Price { get; set; }
    }
}
