using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class OverviewController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Team()
        {
            return View();
        }
    }
}
