using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using WebApplication1.DAL;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly HotelDatabaseContext _dbContext; // những thuộc tính private sẽ gạch dưới
        private readonly IBookingRepository _bookingRepository;
        private readonly ITypeRoomRepository _typeRoomRepository;

        public HomeController(ILogger<HomeController> logger, IBookingRepository bookingRepository, ITypeRoomRepository typeRoomRepository)
        {
            _logger = logger;
            _bookingRepository = bookingRepository;
            _typeRoomRepository = typeRoomRepository;
        }

        public IActionResult SelectTypeRoom()
        {
            return ViewComponent("SelectType");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            var bookings = _bookingRepository.GetAllBookings();
            return View(bookings);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public IActionResult Booking()
        //{
        //    var bookings = _dbContext.Bookings.ToList();
        //    return View(bookings); // trả về list nên để giao diện hiển thị phải sửa thêm trong index

        //}

        //repository 
        //BOOKING
        // GETALL: /Services/
        public IActionResult Booking()
        {
            //var bookings = _bookingRepository.GetAllBookings();
            ////var dichVus = from s in _serviceRepository.GetAllDichVus()
            ////               select s;
            return View();
        }
        // SEARCH: /DetailService/
        public IActionResult DetailBooking(int MaBooking)
        {
            var booking = _bookingRepository.GetBookingById(MaBooking);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }
        // POST: /AddBooking/
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaBooking,MaKh, NgayIn, NgayOut, MaNv, TrangThai, Datcoc, SlKh")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _bookingRepository.InsertBooking(booking);
                _bookingRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }
        // PUT: /UpdateService/
        public IActionResult EditService(int MaBooking)
        {
            var booking = _bookingRepository.GetBookingById(MaBooking);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int MaBooking, [Bind("MaKh, NgayIn, NgayOut, MaNv, TrangThai, Datcoc, SlKh")] Booking booking)
        {
            if (MaBooking != booking.MaBooking)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookingRepository.UpdateBooking(booking);
                    _bookingRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_bookingRepository.GetAllBookings().Any(e => e.MaBooking == MaBooking))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

    }
}
