using KenKata.Models;
using KenKata.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IProductService _productService;

        public ShoppingCartController(ShoppingCart shoppingCart, IProductService productService)
        {
            _shoppingCart = shoppingCart;
            _productService = productService;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppinCartItems();
            _shoppingCart.ShoppinCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _productService.Products.FirstOrDefault(p => p.ProductId == productId);
            if(selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productService.Products.FirstOrDefault(p => p.ProductId == productId);
            if(selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
    }
}
