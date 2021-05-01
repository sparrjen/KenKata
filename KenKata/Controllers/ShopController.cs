using KenKata.Data;
using KenKata.Entities;
using KenKata.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Controllers
{
    public class ShopController : Controller
    {
        private readonly SqlDbProductsContext _context;

        public ShopController(SqlDbProductsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var sqlDbProductsContext = _context.Products.Include(p => p.Brand).Include(p => p.Category);
            return View(await sqlDbProductsContext.ToListAsync());
        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

    }
}
