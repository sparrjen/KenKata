using KenKata.Entities;
using KenKata.Models;
using KenKata.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderService orderService, ShoppingCart shoppingCart)
        {
            _orderService = orderService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            var items = _shoppingCart.GetShoppinCartItems();
            _shoppingCart.ShoppinCartItems = items;

            if (_shoppingCart.ShoppinCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some products first");
            }

            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! :)";
            return View();
        }
    }
}
