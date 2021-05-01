using KenKata.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }

        public Product CategoryName { get; set; }

        public Product BrandName { get; set; }
    }
}
