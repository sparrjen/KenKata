using System;
using System.Collections.Generic;

#nullable disable

namespace KenKata.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();            
            ShoppinCartItems = new HashSet<ShoppinCartItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public byte[] Picture { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }        
        public virtual ICollection<ShoppinCartItem> ShoppinCartItems { get; set; }
    }
}
