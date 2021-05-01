using KenKata.Data;
using KenKata.Models;
using KenKata.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly SqlDbProductsContext _context;
        private readonly IIdentityService _identityService;

        public HomeController(ILogger<HomeController> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            SqlDbProductsContext context,
            IIdentityService identityService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _identityService = identityService;
        }

        public async Task<IActionResult> Index()
        {
            await _identityService.CreateRootAccountAsync();
            var sqlDbProductsContext = _context.Products.Include(p => p.Brand).Include(p => p.Category);
            return View(await sqlDbProductsContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Account(AccountViewModel model, string submit1, string submit2)
        {
            if (submit1 == "LOG IN")
            {
                var result = await _signInManager.PasswordSignInAsync(model.LoginEmail, model.LoginPassword, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            if (submit2 == "REGISTER")
            {
                var user = new IdentityUser { UserName = model.RegisterUserName, Email = model.RegisterEmail };
                var result = await _userManager.CreateAsync(user, model.RegisterPassword);
                if (result.Succeeded)
                {
                    TempData["Message"] = "You have registered successfully";
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
