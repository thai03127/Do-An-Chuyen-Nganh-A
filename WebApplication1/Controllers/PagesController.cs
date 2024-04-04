using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Testimonial()
        {
            return View();
        }


    }
}
