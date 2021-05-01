using KenKata.Data;
using KenKata.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Models
{ 
    public class ShoppingCart
    {
        private readonly SqlDbProductsContext _sqlDbProductsContext;

        public ShoppingCart(SqlDbProductsContext sqlDbProductsContext)
        {
            _sqlDbProductsContext = sqlDbProductsContext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppinCartItem> ShoppinCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<SqlDbProductsContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int quantity)
        {
            var shoppingCartItem = _sqlDbProductsContext.ShoppinCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppinCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Quantity = 1
                };

                _sqlDbProductsContext.ShoppinCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _sqlDbProductsContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = _sqlDbProductsContext.ShoppinCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            var localQuantity = 0;

            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localQuantity = shoppingCartItem.Quantity;
                }
                else
                {
                    _sqlDbProductsContext.ShoppinCartItems.Remove(shoppingCartItem);
                }
            }

            _sqlDbProductsContext.SaveChanges();

            return localQuantity;
        }

        public List<ShoppinCartItem> GetShoppinCartItems()
        {
            return ShoppinCartItems ??
                (ShoppinCartItems = _sqlDbProductsContext.ShoppinCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Include(s => s.Product)
                    .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _sqlDbProductsContext
                .ShoppinCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _sqlDbProductsContext.ShoppinCartItems.RemoveRange(cartItems);

            _sqlDbProductsContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _sqlDbProductsContext.ShoppinCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Quantity).Sum();

            return total;
        }
    }
}
