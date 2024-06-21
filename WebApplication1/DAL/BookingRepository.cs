using Microsoft.EntityFrameworkCore;
using WebApplication1.Data; // Giả sử đây là namespace chứa context của bạn
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDatabaseContext _context;
        public BookingRepository(HotelDatabaseContext context)
        {
            _context = context;
        }
        //IEnumerable Booking
        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }
        //find by id
        public Booking GetBookingById(int MaBooking)
        {
            return _context.Bookings.Find(MaBooking);
        }
        //Insert Booking
        public void InsertBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
        }
        //Update Booking
        public void UpdateBooking(Booking booking)
        {
            var existingBooking = _context.Bookings.Find(booking.MaBooking);
            if (existingBooking != null)
            {
                existingBooking.MaKh = booking.MaKh;
                existingBooking.NgayIn = booking.NgayIn;
                existingBooking.NgayOut = booking.NgayOut;
                existingBooking.MaNv = booking.MaNv;
                existingBooking.TrangThai = booking.TrangThai;
                existingBooking.DatCoc = booking.DatCoc;
                existingBooking.SlKh = booking.SlKh;

                _context.SaveChanges();
            }
        }

        //Delete Booking
        public void DeleteBooking(int MaBooking)
        {
            Booking booking = _context.Bookings.Find(MaBooking);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
