using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMS.Models
{
    public class Product
    {
        public string Id { get; set; }

        [RequiredSis]
        [MaxLength(20)]
        public string Name { get; set; }

        [RangeSis(0.05, 1000, "Price should be between 0.05 and 1000")]
        public decimal Price { get; set; }
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
