using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Room()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }
    }
}
