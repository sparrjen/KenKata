using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogDetails()
        {
            return View();
        }
    }
}
