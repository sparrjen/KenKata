using KenKata.Data;
using KenKata.Entities;
using KenKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Services
{
    public class OrderService : IOrderService
    {
        private readonly SqlDbProductsContext _sqlDbProductsContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderService(SqlDbProductsContext sqlDbProductsContext, ShoppingCart shoppingCart)
        {
            _sqlDbProductsContext = sqlDbProductsContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            _sqlDbProductsContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppinCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = item.Quantity,
                    ProductId = item.Product.ProductId,
                    OrderId = order.OrderId,
                    Price = item.Product.Price
                };

                _sqlDbProductsContext.OrderDetails.Add(orderDetail);
            }
            _sqlDbProductsContext.SaveChanges();
        }
    }
}
