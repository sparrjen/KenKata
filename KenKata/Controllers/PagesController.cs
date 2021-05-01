using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Team()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult PortfolioDetails()
        {
            return View();
        }
    }
}
