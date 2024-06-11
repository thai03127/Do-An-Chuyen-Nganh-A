using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class OverviewController : Controller
    {
        private readonly ILogger<OverviewController> _logger;
        private readonly HotelDatabaseContext _dbContext; // những thuộc tính private sẽ gạch dưới

        public OverviewController(ILogger<OverviewController> logger, HotelDatabaseContext context)
        {
            _logger = logger;
            _dbContext = context;
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Team()
        {
            var nhanViens = _dbContext.NhanViens.ToList();
            return View(nhanViens);  
        }
    }
}
