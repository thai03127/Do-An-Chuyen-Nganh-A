using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

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
            _context.Entry(booking).State = EntityState.Modified;
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

        Booking IBookingRepository.GetBookingById(int MaBooking) => throw new NotImplementedException();
    }
}
