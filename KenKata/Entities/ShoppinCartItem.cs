using System;
using System.Collections.Generic;

#nullable disable

namespace KenKata.Entities
{
    public partial class ShoppinCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartId { get; set; }

        public virtual Product Product { get; set; }
    }
}
