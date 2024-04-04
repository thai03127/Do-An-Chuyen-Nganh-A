using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HotelContext _dbContext; // những thuộc tính private sẽ gạch dưới

        public HomeController(ILogger<HomeController> logger, HotelContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var bookings = _dbContext.Bookings.ToList();
            return View(bookings); // trả về list nên để giao diện hiển thị phải sửa thêm trong index
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
